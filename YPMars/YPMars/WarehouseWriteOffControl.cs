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
    public partial class WarehouseWriteOffControl : UserControl
    {
        private List<WarehouseItem> _items;
        private WarehouseModel _model;
        private User _currentUser;
        private Action _onSuccess;

        public WarehouseWriteOffControl()
        {
            InitializeComponent();

            // Настраиваем поиск
            NomenclatureComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            NomenclatureComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            NomenclatureComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

            QuantityNumeric.ValueChanged += (s, e) => UpdateTotal();
            NomenclatureComboBox.TextChanged += (s, e) => OnNomenclatureChanged();
            NomenclatureComboBox.SelectedIndexChanged += (s, e) => OnNomenclatureChanged();
        }

        public void Initialize(WarehouseModel model, User currentUser, Action onSuccess)
        {
            _model = model;
            _currentUser = currentUser;
            _onSuccess = onSuccess;

            _items = _model.Items ?? new List<WarehouseItem>();

            // Заполняем ComboBox только именами (строками)
            NomenclatureComboBox.Items.Clear();
            foreach (var item in _items)
            {
                NomenclatureComboBox.Items.Add(item.NomenclatureName);
            }

            if (NomenclatureComboBox.Items.Count > 0)
                NomenclatureComboBox.SelectedIndex = 0;
            else
                OnNomenclatureChanged();
        }

        private void UpdateTotal()
        {
            decimal price = decimal.TryParse(UnitPriceTextBox.Text, out var p) ? p : 0m;
            TotalSumLabel.Text = $"Сумма: {(price * QuantityNumeric.Value):N2} руб.";
        }

        private void OnNomenclatureChanged()
        {
            string name = NomenclatureComboBox.Text.Trim();

            // Ищем объект по имени (с учетом регистра)
            var item = _items.FirstOrDefault(x => string.Equals(x.NomenclatureName, name, StringComparison.OrdinalIgnoreCase));

            if (item != null)
            {
                AvailableQuantityLabel.Text = $"Доступно: {item.AvailableQuantity} шт.";
                UnitPriceTextBox.Text = item.UnitPrice.ToString("N2");

                QuantityNumeric.Maximum = Math.Max(1, item.AvailableQuantity);
                if (QuantityNumeric.Value > QuantityNumeric.Maximum)
                    QuantityNumeric.Value = QuantityNumeric.Maximum;
            }
            else
            {
                AvailableQuantityLabel.Text = "Доступно: 0 шт.";
                UnitPriceTextBox.Text = "0,00";
                QuantityNumeric.Maximum = 1;
            }
            UpdateTotal();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = NomenclatureComboBox.Text.Trim();
            var selected = _items.FirstOrDefault(x => string.Equals(x.NomenclatureName, name, StringComparison.OrdinalIgnoreCase));

            if (selected == null)
            {
                MessageBox.Show("Необходимо выбрать номенклатуру из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (QuantityNumeric.Value <= 0)
            {
                MessageBox.Show("Количество должно быть больше нуля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (QuantityNumeric.Value > selected.AvailableQuantity)
            {
                MessageBox.Show($"Недостаточно остатка. Доступно: {selected.AvailableQuantity} шт.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var writeOffItem = new WarehouseItem
            {
                NomenclatureName = selected.NomenclatureName,
                StorageZone = selected.StorageZone,
                TotalQuantity = (int)QuantityNumeric.Value,
                ReservedQuantity = 0,
                UnitPrice = selected.UnitPrice
            };

            if (_model.RegisterWriteOff(writeOffItem, _currentUser?.Login ?? "", out string error))
            {
                MessageBox.Show("Списание успешно оформлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _onSuccess?.Invoke();
                Initialize(_model, _currentUser, _onSuccess);
            }
            else
            {
                MessageBox.Show(error, "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            if (_model == null) return;

            using (var form = new WarehouseWriteOffReportForm(_model))
            {
                form.ShowDialog(this);
            }
        }
    }
}
