using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YPMarsLib;

namespace YPMars
{
    public partial class MainForm : Form
    {
        private const int DefaultPeriodDays = 30;
        private UserPgRepository loader_;
        private User currentUser_;
        private OrderManager _orderManager;

        private string _currentSortField = "OrderDate";
        private bool _isAscending = false;

        public MainForm(UserPgRepository loader, User currentUser)
        {
            InitializeComponent();
            loader_ = loader;
            currentUser_ = currentUser;

            IOrderListRepository repository = new OrderListRepository();
            _orderManager = new OrderManager(repository);

            if (currentUser_.Role != User.UserRole.SuperUser)
                RegistrButton.Visible = false;

            if (currentUser_.Role != User.UserRole.SuperUser && currentUser_.Role != User.UserRole.Warehouser)
                panelBottom.Visible = false;

            NewOrderButton.Visible = (currentUser_.Role == User.UserRole.ManageSale);

            RefreshButton.Click += RefreshButton_Click;
            ChangeStatusButton.Click += ChangeStatusButton_Click;
            NewOrderButton.Click += NewOrderButton_Click;
            RegistrButton.Click += RegistrButton_Click;
            this.Load += MainForm_Load;

            if (OrdersDataGridView.Columns["ContractNumber"] != null)
                OrdersDataGridView.Columns["ContractNumber"].DataPropertyName = "ContractNumber";
            if (OrdersDataGridView.Columns["OrderDate"] != null)
                OrdersDataGridView.Columns["OrderDate"].DataPropertyName = "OrderDate";
            if (OrdersDataGridView.Columns["Status"] != null)
                OrdersDataGridView.Columns["Status"].DataPropertyName = "StatusText"; 
            if (OrdersDataGridView.Columns["PlannedShipmentDate"] != null)
                OrdersDataGridView.Columns["PlannedShipmentDate"].DataPropertyName = "PlannedShipmentDate";
            if (OrdersDataGridView.Columns["CounterpartyName"] != null)
                OrdersDataGridView.Columns["CounterpartyName"].DataPropertyName = "CounterpartyName";

            foreach (DataGridViewColumn col in OrdersDataGridView.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }

            OrdersDataGridView.ColumnHeaderMouseClick += OrdersDataGridView_ColumnHeaderMouseClick;
            OrdersDataGridView.CellFormatting += OrdersDataGridView_CellFormatting;

            var dir = new Directory();
            cmbCounterparty.DataSource = dir.GetCounterparties();
            cmbCounterparty.SelectedIndex = -1;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            StartDateDatetimePick.Value = DateTime.Now.AddDays(-DefaultPeriodDays);
            EndDateDatetimePick.Value = DateTime.Now;

            SetupStatusComboBox();
            LoadOrders();
        }

        private void LoadOrders()
        {
            var filterDate = new OrderDateFilter
            {
                StartDate = StartDateDatetimePick.Value.Date,
                EndDate = EndDateDatetimePick.Value.Date.AddDays(1).AddTicks(-1)
            };

            List<Order> orders = _orderManager.GetOrders(filterDate, out string error);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OrdersDataGridView.DataSource = null;
                UpdateFooter();
                return;
            }

            if (cmbCounterparty.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(cmbCounterparty.Text))
            {
                orders = orders.Where(o => o.CounterpartyName == cmbCounterparty.Text).ToList();
            }

            OrdersDataGridView.DataSource = orders;
            UpdateFooter();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void ApplyFilterButton_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void OrdersDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string clickedColumn = OrdersDataGridView.Columns[e.ColumnIndex].DataPropertyName;

            if (string.IsNullOrWhiteSpace(clickedColumn))
                return;

            if (_currentSortField == clickedColumn)
            {
                _isAscending = !_isAscending;
            }
            else
            {
                _currentSortField = clickedColumn;
                _isAscending = true;
            }

            if (OrdersDataGridView.DataSource is List<Order> currentList)
            {
                List<Order> sortedList;
                switch (_currentSortField)
                {
                    case "ContractNumber":
                        sortedList = _isAscending ? currentList.OrderBy(o => o.ContractNumber).ToList() : currentList.OrderByDescending(o => o.ContractNumber).ToList();
                        break;
                    case "OrderDate":
                        sortedList = _isAscending ? currentList.OrderBy(o => o.OrderDate).ToList() : currentList.OrderByDescending(o => o.OrderDate).ToList();
                        break;
                    case "StatusText":
                        sortedList = _isAscending ? currentList.OrderBy(o => o.Status).ToList() : currentList.OrderByDescending(o => o.Status).ToList();
                        break;
                    case "PlannedShipmentDate":
                        sortedList = _isAscending ? currentList.OrderBy(o => o.PlannedShipmentDate).ToList() : currentList.OrderByDescending(o => o.PlannedShipmentDate).ToList();
                        break;
                    default:
                        sortedList = currentList;
                        break;
                }
                OrdersDataGridView.DataSource = sortedList;
            }
        }

        private void OrdersDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime dateValue)
            {
                string colName = OrdersDataGridView.Columns[e.ColumnIndex].DataPropertyName;
                if (colName == "OrderDate" || colName == "PlannedShipmentDate")
                {
                    e.Value = dateValue.ToString("dd.MM.yyyy");
                    e.FormattingApplied = true;
                }
            }
        }

        private void SetupStatusComboBox()
        {
            var statuses = new Dictionary<OrderStatus, string>
            {
                { OrderStatus.New, "Новый" },
                { OrderStatus.InProgress, "В работе" },
                { OrderStatus.ReadyForShipment, "Готов к отгрузке" },
                { OrderStatus.Shipment, "Отгружен" },
                { OrderStatus.Completed, "Завершен" },
                { OrderStatus.Cancelled, "Отменен" }
            };

            StatusCoboBox.DataSource = new BindingSource(statuses, null);
            StatusCoboBox.DisplayMember = "Value";
            StatusCoboBox.ValueMember = "Key";
        }

        private void UpdateFooter()
        {
            int totalCount = _orderManager.GetTotalCount();
            decimal totalSum = _orderManager.GetTotalSum();

            TotalCountLabel.Text = $"Всего заказов: {totalCount}";
            TotalSumLabel.Text = $"Итоговая сумма: {totalSum.ToString("N2")} руб.";
        }

        private void ChangeStatusButton_Click(object sender, EventArgs e)
        {
            if (OrdersDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ в таблице для смены статуса.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedOrder = (Order)OrdersDataGridView.SelectedRows[0].DataBoundItem;
            var selectedPair = (KeyValuePair<OrderStatus, string>)StatusCoboBox.SelectedItem;
            OrderStatus newStatus = selectedPair.Key;

            string error = _orderManager.UpdateStatus(selectedOrder.ContractNumber, newStatus);

            if (string.IsNullOrEmpty(error))
            {
                selectedOrder.Status = newStatus;
                OrdersDataGridView.Refresh();
                UpdateFooter();
                MessageBox.Show("Статус заказа успешно обновлён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(error, "Ошибка обновления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NewOrderButton_Click(object sender, EventArgs e)
        {
            using (var form = new OrderEditForm(currentUser_))
            {
                form.ShowDialog(this);
            }
            LoadOrders();
        }

        private void RegistrButton_Click(object sender, EventArgs e)
        {
            RegistrForm registrForm = new RegistrForm(loader_, currentUser_);
            registrForm.Show();
        }

        private void OpenOrderDetails()
        {
            if (OrdersDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ в таблице для просмотра состава.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedOrder = OrdersDataGridView.SelectedRows[0].DataBoundItem as Order;
            if (selectedOrder == null) return;

            IOrderListRepository repository = new OrderListRepository();
            var orderManager = new OrderManager(repository);

            var detailsForm = new OrderDetailsForm(selectedOrder, orderManager);
            if (detailsForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadOrders();
            }
        }

        private void OrderDetailsButton_Click(object sender, EventArgs e)
        {
            OpenOrderDetails();
        }

        private void OrdersDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenOrderDetails();
        }
    }
}
