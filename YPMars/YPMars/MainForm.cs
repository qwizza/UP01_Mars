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
        private OrderManager orderManager_;
        private WarehouseModel warehouseModel_;

        private string _currentSortField = "OrderDate";
        private bool _isAscending = false;

        public MainForm(UserPgRepository loader, User currentUser)
        {
            InitializeComponent();
            loader_ = loader;
            currentUser_ = currentUser;

            orderManager_ = new OrderManager(new OrderListRepository());
            warehouseModel_ = new WarehouseModel(new WarehouseRepository());

            if (currentUser_.Role != User.UserRole.SuperUser)
                RegistrButton.Visible = false;

            NewOrderButton.Visible = (currentUser_.Role == User.UserRole.ManageSale || currentUser_.Role == User.UserRole.SuperUser);

            RefreshButton.Click += RefreshButton_Click;
            ChangeStatusButton.Click += ChangeStatusButton_Click;
            NewOrderButton.Click += NewOrderButton_Click;

            OrdersDataGridView.ColumnHeaderMouseClick += OrdersDataGridView_ColumnHeaderMouseClick;
            OrdersDataGridView.CellFormatting += OrdersDataGridView_CellFormatting;
            OrdersDataGridView.CellDoubleClick += OrdersDataGridView_CellDoubleClick;

            var dir = new Directory();
            cmbCounterparty.DataSource = dir.GetCounterparties();
            cmbCounterparty.SelectedIndex = -1;

            // ФИО и роль
            string displayName = string.IsNullOrWhiteSpace(currentUser_.FullName) ? currentUser_.Login : currentUser_.FullName;
            string roleText = string.Empty;
            switch (currentUser_.Role)
            {
                case User.UserRole.SuperUser: roleText = "Супер-пользователь"; break;
                case User.UserRole.ManageSale: roleText = "Менеджер по продажам"; break;
                case User.UserRole.Warehouser: roleText = "Кладовщик"; break;
            }
            UserInfoLabel.Text = $"{displayName} ({roleText})";

            ConfigureTabsByRole();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartDateDatetimePick.Value = DateTime.Now.AddDays(-DefaultPeriodDays);
            EndDateDatetimePick.Value = DateTime.Now;
            SetupStatusComboBox();

            // Инициализация вкладок склада
            warehouseControl1.Initialize(warehouseModel_, currentUser_);

            // Обновление склада после операций
            Action updateWarehouse = () => warehouseControl1.LoadStock();

            warehouseReceiptControl1.Initialize(warehouseModel_, currentUser_, updateWarehouse);
            warehouseWriteOffControl1.Initialize(warehouseModel_, currentUser_, updateWarehouse);

            LoadOrders();
        }

        private void ConfigureTabsByRole()
        {
            if (currentUser_.Role == User.UserRole.Warehouser)
            {
                tabControl1.TabPages.Remove(tabOrders);
            }
            else if (currentUser_.Role == User.UserRole.ManageSale)
            {
                tabControl1.TabPages.Remove(tabWarehouse);
                tabControl1.TabPages.Remove(tabReceipt);
                tabControl1.TabPages.Remove(tabWriteOff);
            }
        }

        private void LoadOrders()
        {
            var filterDate = new OrderDateFilter
            {
                StartDate = StartDateDatetimePick.Value.Date,
                EndDate = EndDateDatetimePick.Value.Date.AddDays(1).AddTicks(-1)
            };

            List<Order> orders = orderManager_.GetOrders(filterDate, out string error);

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

        private void RefreshButton_Click(object sender, EventArgs e) => LoadOrders();

        private void ApplyFilterButton_Click(object sender, EventArgs e) => LoadOrders();

        private void OrdersDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string clickedColumn = OrdersDataGridView.Columns[e.ColumnIndex].DataPropertyName;
            if (string.IsNullOrWhiteSpace(clickedColumn)) return;

            if (_currentSortField == clickedColumn) _isAscending = !_isAscending;
            else { _currentSortField = clickedColumn; _isAscending = true; }

            if (OrdersDataGridView.DataSource is List<Order> currentList)
            {
                List<Order> sortedList;
                switch (_currentSortField)
                {
                    case "ContractNumber": sortedList = _isAscending ? currentList.OrderBy(o => o.ContractNumber).ToList() : currentList.OrderByDescending(o => o.ContractNumber).ToList(); break;
                    case "OrderDate": sortedList = _isAscending ? currentList.OrderBy(o => o.OrderDate).ToList() : currentList.OrderByDescending(o => o.OrderDate).ToList(); break;
                    case "StatusText": sortedList = _isAscending ? currentList.OrderBy(o => o.Status).ToList() : currentList.OrderByDescending(o => o.Status).ToList(); break;
                    case "PlannedShipmentDate": sortedList = _isAscending ? currentList.OrderBy(o => o.PlannedShipmentDate).ToList() : currentList.OrderByDescending(o => o.PlannedShipmentDate).ToList(); break;
                    default: sortedList = currentList; break;
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
                { OrderStatus.New, "Новый" }, { OrderStatus.InProgress, "В работе" },
                { OrderStatus.ReadyForShipment, "Готов к отгрузке" }, { OrderStatus.Shipment, "Отгружен" },
                { OrderStatus.Completed, "Завершен" }, { OrderStatus.Cancelled, "Отменен" }
            };
            StatusCoboBox.DataSource = new BindingSource(statuses, null);
            StatusCoboBox.DisplayMember = "Value";
            StatusCoboBox.ValueMember = "Key";
        }

        private void UpdateFooter()
        {
            TotalCountLabel.Text = $"Всего заказов: {orderManager_.GetTotalCount()}";
            TotalSumLabel.Text = $"Итоговая сумма: {orderManager_.GetTotalSum():N2} руб.";
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
            string error = orderManager_.UpdateStatus(selectedOrder.ContractNumber, selectedPair.Key);

            if (string.IsNullOrEmpty(error))
            {
                selectedOrder.Status = selectedPair.Key;
                OrdersDataGridView.Refresh();
                UpdateFooter();
                MessageBox.Show("Статус заказа успешно обновлён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show(error, "Ошибка обновления", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NewOrderButton_Click(object sender, EventArgs e)
        {
            using (var form = new OrderEditForm(currentUser_)) form.ShowDialog(this);
            LoadOrders();
        }

        private void RegistrButton_Click(object sender, EventArgs e)
        {
            new RegistrForm(loader_, currentUser_).Show();
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

            var detailsForm = new OrderDetailsForm(selectedOrder, orderManager_);
            if (detailsForm.ShowDialog(this) == DialogResult.OK) LoadOrders();
        }

        private void OrderDetailsButton_Click(object sender, EventArgs e) => OpenOrderDetails();
        private void OrdersDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => OpenOrderDetails();
    }
}
