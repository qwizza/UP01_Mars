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
    public partial class OrderEditForm : Form
    {
        private readonly User _currentUser;
        private readonly IOrderRepository _orderRepository;
        private readonly Directory directory_;
        private readonly ContractNumberGenerator numberGenerator_;
        private readonly OrderValidator validator_;
        private readonly List<OrderItem> items_ = new List<OrderItem>();

        public OrderEditForm(User currentUser, IOrderRepository orderRepository = null)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _orderRepository = orderRepository ?? new OrderRepository();
            directory_ = new Directory();
            numberGenerator_ = new ContractNumberGenerator();
            validator_ = new OrderValidator();

            Load += OrderEditForm_Load;
        }

        private void OrderEditForm_Load(object sender, EventArgs e)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            // Задаем начальные значения
            PlannedShipmentDatePicker.Value = DateTime.Now.AddDays(7);

            QuantityNumeric.Minimum = 1;
            QuantityNumeric.Maximum = 1_000_000;
            QuantityNumeric.Value = 1;

            SetupItemsGrid();
            UpdateTotalSum();
        }

        private void SetupItemsGrid()
        {
            ItemsGrid.Columns.Clear();
            ItemsGrid.AutoGenerateColumns = false;
            ItemsGrid.AllowUserToAddRows = false;
            ItemsGrid.ReadOnly = true;
            ItemsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ItemsGrid.MultiSelect = false;
            ItemsGrid.RowHeadersVisible = false;

            ItemsGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Номенклатура",
                DataPropertyName = "NomenclatureName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            ItemsGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Количество",
                DataPropertyName = "Quantity",
                Width = 120
            });
            ItemsGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Цена",
                DataPropertyName = "UnitPrice",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });
            ItemsGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Сумма",
                DataPropertyName = "TotalPrice",
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });
        }

        // =========================================================
        // ЛОГИКА ПОИСКА КОНТРАГЕНТА
        // =========================================================

        private void CounterpartyTextBox_TextChanged(object sender, EventArgs e)
        {
            string query = CounterpartyTextBox.Text.Trim();

            // Если поле пустое — показываем ВСЕ элементы
            if (string.IsNullOrEmpty(query))
            {
                var allItems = directory_.GetCounterparties(); // Ваш метод получения всех
                CounterpartyListBox.DataSource = allItems;
                CounterpartyListBox.Visible = allItems.Count > 0;
                return;
            }

            // Если что-то введено — ищем совпадения
            var suggestions = directory_.SearchCounterparties(query);
            CounterpartyListBox.DataSource = suggestions;
            CounterpartyListBox.Visible = suggestions.Count > 0;
        }

        // Добавьте это событие, чтобы при клике на пустое поле список открывался
        private void CounterpartyTextBox_Enter(object sender, EventArgs e)
        {
            CounterpartyTextBox_TextChanged(sender, e); // Вызываем логику отображения
        }

        private void CounterpartyListBox_DoubleClick(object sender, EventArgs e)
        {
            if (CounterpartyListBox.SelectedItem != null)
            {
                CounterpartyTextBox.Text = CounterpartyListBox.SelectedItem.ToString();
                CounterpartyListBox.Visible = false;
            }
        }

        // =========================================================
        // ЛОГИКА ПОИСКА НОМЕНКЛАТУРЫ
        // =========================================================

        private void NomenclatureTextBox_TextChanged(object sender, EventArgs e)
        {
            string query = NomenclatureTextBox.Text.Trim();

            // Если поле пустое — показываем ВСЕ элементы
            if (string.IsNullOrEmpty(query))
            {
                var allItems = directory_.GetNomenclature(); // Ваш метод получения всех
                NomenclatureListBox.DataSource = allItems;
                NomenclatureListBox.Visible = allItems.Count > 0;
                return;
            }

            // Если что-то введено — ищем совпадения
            var suggestions = directory_.SearchNomenclature(query);
            NomenclatureListBox.DataSource = suggestions;
            NomenclatureListBox.Visible = suggestions.Count > 0;
        }

        // Добавьте это событие, чтобы при клике на пустое поле список открывался
        private void NomenclatureTextBox_Enter(object sender, EventArgs e)
        {
            NomenclatureTextBox_TextChanged(sender, e);
        }

        private void NomenclatureListBox_DoubleClick(object sender, EventArgs e)
        {
            if (NomenclatureListBox.SelectedItem != null)
            {
                NomenclatureTextBox.Text = NomenclatureListBox.SelectedItem.ToString();
                NomenclatureListBox.Visible = false;
            }
        }

        // =========================================================
        // ДОБАВЛЕНИЕ ПОЗИЦИИ
        // =========================================================

        private void AddItemButton_Click(object sender, EventArgs e)
        {
            // Проверка контрагента
            if (string.IsNullOrWhiteSpace(CounterpartyTextBox.Text))
            {
                MessageBox.Show("Выберите контрагента", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка номенклатуры (берем текст из TextBox)
            string nomenclature = NomenclatureTextBox.Text?.Trim();

            if (string.IsNullOrWhiteSpace(nomenclature))
            {
                MessageBox.Show("Выберите номенклатуру", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantity = (int)QuantityNumeric.Value;
            if (quantity <= 0)
            {
                MessageBox.Show("Количество должно быть больше нуля", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Цена подставляется из справочника
            decimal unitPrice = directory_.GetUnitPrice(nomenclature);
            if (unitPrice <= 0)
            {
                MessageBox.Show("Не удалось определить цену для выбранной номенклатуры", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            items_.Add(new OrderItem
            {
                NomenclatureName = nomenclature,
                Quantity = quantity,
                UnitPrice = unitPrice
            });

            RefreshItemsGrid();

            // Очищаем поле номенклатуры и количество для добавления следующей позиции
            NomenclatureTextBox.Clear();
            QuantityNumeric.Value = 1;
        }

        private void RefreshItemsGrid()
        {
            ItemsGrid.DataSource = null;
            ItemsGrid.DataSource = items_;
            UpdateTotalSum();
        }

        private void UpdateTotalSum()
        {
            decimal total = 0;
            foreach (var item in items_)
            {
                total += item.TotalPrice;
            }
            TotalSumLabel.Text = $"Итоговая сумма: {total:N2} руб.";
        }

        // =========================================================
        // СОХРАНЕНИЕ ЗАКАЗА
        // =========================================================

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // 1. Формируем объект Order из полей формы
            var order = new Order
            {
                OrderDate = DateTime.Now,
                CounterpartyName = CounterpartyTextBox.Text?.Trim(), // Берем из TextBox
                PlannedShipmentDate = PlannedShipmentDatePicker.Value.Date,
                Status = OrderStatus.New,
                Items = new List<OrderItem>(items_)
            };

            // 2. Валидация
            string validationError = validator_.Validate(order);
            if (!string.IsNullOrEmpty(validationError))
            {
                MessageBox.Show(validationError, "Проверка данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Генерация номера договора
            int lastNumber = _orderRepository.GetLastOrderNumberInYear(order.OrderDate.Year);
            order.ContractNumber = numberGenerator_.Generate(order.OrderDate, lastNumber);

            // 4. Сохранение
            string saveError = _orderRepository.CreateOrder(order);
            if (!string.IsNullOrEmpty(saveError))
            {
                MessageBox.Show(saveError, "Ошибка сохранения",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 5. Успех
            MessageBox.Show(
                $"Заказ №{order.ContractNumber} успешно создан. Сумма: {order.TotalAmount:N2} руб.",
                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK; // Важно для обновления главной формы
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}