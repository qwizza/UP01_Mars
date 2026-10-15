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
    public partial class OrderListForm : Form
    {
        private const int DefaultPeriodDays = 30;
        private readonly UserPgRepository _loader;
        private readonly User _currentUser;
        private readonly OrderManager _orderManager;

        public OrderListForm(UserPgRepository loader, User currentUser)
        {
            InitializeComponent();
            _loader = loader;
            _currentUser = currentUser;

            IOrderListRepository repository = new OrderListRepository();
            _orderManager = new OrderManager(repository);

            if (_currentUser.Role != User.UserRole.SuperUser && _currentUser.Role != User.UserRole.Warehouser)
            {
                panelBottom.Visible = false;
            }

            RefreshButton.Click += RefreshButton_Click;
            ChangeStatusButton.Click += ChangeStatusButton_Click;
            this.Load += OrderListForm_Load;
            NewOrderButton.Visible = (_currentUser.Role == User.UserRole.ManageSale);
            NewOrderButton.Click += NewOrderButton_Click;
        }

        private void OrderListForm_Load(object sender, EventArgs e)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            StartDateDatetimePick.Value = DateTime.Now.AddDays(-DefaultPeriodDays);
            EndDateDatetimePick.Value = DateTime.Now;

            SetupStatusComboBox();
            LoadOrders();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
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

            OrdersDataGridView.DataSource = orders;

            UpdateFooter();
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

            TotalCountLabel.Text = $"Всего заказов: {totalCount}.";
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
            using (var form = new OrderEditForm(_currentUser))
            {
                form.ShowDialog(this);
            }
            LoadOrders();
        }
    }
}
