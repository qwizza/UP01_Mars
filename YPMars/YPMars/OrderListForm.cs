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
        private readonly UserPgRepository _loader;
        private readonly User _currentUser;
        private readonly IOrderListRepository _repository;

        // Конструктор формы
        public OrderListForm(UserPgRepository loader, User currentUser)
        {
            InitializeComponent();
            _loader = loader;
            _currentUser = currentUser;

            // Инициализируем репозиторий заказов (подключение к MarsFactoryDB)
            _repository = new OrderListRepository();

            // Проверка прав: если не Супер-пользователь, скрываем панель смены статуса
            if (_currentUser.Role != User.UserRole.SuperUser)
            {
                panelBottom.Visible = false;
            }

            // Подписка на события
            RefreshButton.Click += RefreshButton_Click;
            ChangeStatusButton.Click += ChangeStatusButton_Click;
            OrdersDataGrideView.CellFormatting += OrdersDataGrideView_CellFormatting;
            this.Load += OrderListForm_Load;
        }

        private void OrderListForm_Load(object sender, EventArgs e)
        {
            // Период по умолчанию: последние 30 дней
            StartDateDatetimePick.Value = DateTime.Now.AddDays(-30);
            EndDateDatetimePick.Value = DateTime.Now;

            // Заполняем выпадающий список статусов русскими названиями
            SetupStatusComboBox();

            LoadOrders();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            var filter = new OrderDateFilter
            {
                StartDate = StartDateDatetimePick.Value.Date,
                EndDate = EndDateDatetimePick.Value.Date.AddDays(1).AddSeconds(-1)
            };

            List<OrderRow> orders = _repository.GetOrdersByPeriod(filter, out string error);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OrdersDataGrideView.DataSource = null;
                UpdateFooter(0, 0);
                return;
            }

            OrdersDataGrideView.DataSource = orders;

            // Переименовываем заголовки столбцов на русский язык
            FormatDataGridViewColumns();

            int totalCount = orders.Count;
            decimal totalSum = 0;
            foreach (var ord in orders)
            {
                totalSum += ord.TotalAmount;
            }

            UpdateFooter(totalCount, totalSum);
        }

        private void FormatDataGridViewColumns()
        {
            if (OrdersDataGrideView.Columns["ContractNumber"] != null)
                OrdersDataGrideView.Columns["ContractNumber"].HeaderText = "Номер договора";

            if (OrdersDataGrideView.Columns["OrderDate"] != null)
                OrdersDataGrideView.Columns["OrderDate"].HeaderText = "Дата заказа";

            if (OrdersDataGrideView.Columns["CounterpartyName"] != null)
                OrdersDataGrideView.Columns["CounterpartyName"].HeaderText = "Контрагент";

            if (OrdersDataGrideView.Columns["Status"] != null)
                OrdersDataGrideView.Columns["Status"].HeaderText = "Статус";

            if (OrdersDataGrideView.Columns["PlannedShipmentDate"] != null)
                OrdersDataGrideView.Columns["PlannedShipmentDate"].HeaderText = "План. отгрузка";

            if (OrdersDataGrideView.Columns["PositionCount"] != null)
                OrdersDataGrideView.Columns["PositionCount"].HeaderText = "Кол-во позиций";

            if (OrdersDataGrideView.Columns["TotalAmount"] != null)
            {
                OrdersDataGrideView.Columns["TotalAmount"].HeaderText = "Итоговая сумма";
                OrdersDataGrideView.Columns["TotalAmount"].DefaultCellStyle.Format = "N2";
            }
        }

        private void SetupStatusComboBox()
        {
            // Словарь сопоставления статусов энумератора и их русских названий
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
            StatusCoboBox.DisplayMember = "Value"; // Отображает русский текст пользователю
            StatusCoboBox.ValueMember = "Key";     // Хранит системный OrderStatus для базы данных
        }

        private void UpdateFooter(int count, decimal sum)
        {
            TotalCountLabel.Text = $"Всего заказов: {count}.";
            TotalSumLabel.Text = $"Итоговая сумма: {sum.ToString("N2")} руб.";
        }

        // Перевод английских статусов в русской таблице «на лету»
        private void OrdersDataGrideView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (OrdersDataGrideView.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string statusStr = e.Value.ToString();

                switch (statusStr)
                {
                    case "New":
                        e.Value = "Новый";
                        e.FormattingApplied = true;
                        break;
                    case "InProgress":
                        e.Value = "В работе";
                        e.FormattingApplied = true;
                        break;
                    case "ReadyForShipment":
                        e.Value = "Готов к отгрузке";
                        e.FormattingApplied = true;
                        break;
                    case "Shipment":
                        e.Value = "Отгружен";
                        e.FormattingApplied = true;
                        break;
                    case "Completed":
                        e.Value = "Завершен";
                        e.FormattingApplied = true;
                        break;
                    case "Cancelled":
                        e.Value = "Отменен";
                        e.FormattingApplied = true;
                        break;
                }
            }
        }

        private void ChangeStatusButton_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка в таблице
            if (OrdersDataGrideView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ в таблице для смены статуса.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем выбранный заказ из строки таблицы
            var selectedOrder = (OrderRow)OrdersDataGrideView.SelectedRows[0].DataBoundItem;

            // Безопасно извлекаем выбранный статус из KeyValuePair
            var selectedPair = (KeyValuePair<OrderStatus, string>)StatusCoboBox.SelectedItem;
            OrderStatus newStatus = selectedPair.Key;

            // Вызываем метод обновления статуса в базе данных
            string error = _repository.UpdateOrderStatus(selectedOrder.ContractNumber, newStatus);

            if (string.IsNullOrEmpty(error))
            {
                MessageBox.Show("Статус заказа успешно обновлён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrders(); // Перезагружаем таблицу для отображения актуальных данных
            }
            else
            {
                MessageBox.Show(error, "Ошибка обновления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
