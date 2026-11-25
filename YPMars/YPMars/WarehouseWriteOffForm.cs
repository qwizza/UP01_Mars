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
    public partial class WarehouseWriteOffForm : Form
    {
        public WarehouseItem WriteOffItem { get; private set; }
        private readonly List<WarehouseItem> _items;

        public WarehouseWriteOffForm(List<WarehouseItem> items)
        {
            InitializeComponent();
            _items = items ?? new List<WarehouseItem>();

            NomenclatureComboBox.DataSource = _items;
            NomenclatureComboBox.DisplayMember = nameof(WarehouseItem.NomenclatureName);
            NomenclatureComboBox.SelectedIndex = _items.Count > 0 ? 0 : -1;

            NomenclatureComboBox.SelectedIndexChanged += (s, e) => OnNomenclatureChanged();
            QuantityNumeric.ValueChanged += (s, e) => UpdateTotal();
            OnNomenclatureChanged();
        }

        private void OnNomenclatureChanged()
        {
            if (NomenclatureComboBox.SelectedItem is WarehouseItem item)
            {
                int available = Math.Max(0, item.AvailableQuantity);
                AvailableQuantityLabel.Text = $"Доступно: {item.AvailableQuantity} шт.";
                UnitPriceTextBox.Text = item.UnitPrice.ToString("N2");
                QuantityNumeric.Maximum = Math.Max(1, item.AvailableQuantity);
                QuantityNumeric.Maximum = Math.Max(1, available);
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

        private void UpdateTotal()
        {
            decimal price = decimal.TryParse(UnitPriceTextBox.Text, out var p) ? p : 0m;
            TotalSumLabel.Text = $"Сумма: {(price * QuantityNumeric.Value):N2} руб.";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!(NomenclatureComboBox.SelectedItem is WarehouseItem selected))
            {
                MessageBox.Show("Необходимо указать наименование номенклатуры.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            if (QuantityNumeric.Value > Math.Max(0, selected.AvailableQuantity))
            {
                MessageBox.Show($"Недостаточно доступного остатка для списания. Доступно: {Math.Max(0, selected.AvailableQuantity)} шт.",
                    "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            if (QuantityNumeric.Value <= 0)
            {
                MessageBox.Show("Количество списания должно быть больше нуля.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            if (QuantityNumeric.Value > Math.Max(0, selected.AvailableQuantity))
            {
                MessageBox.Show($"Недостаточно доступного остатка для списания. Доступно: {Math.Max(0, selected.AvailableQuantity)} шт.",
                    "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            WriteOffItem = new WarehouseItem
            {
                NomenclatureName = selected.NomenclatureName,
                StorageZone = selected.StorageZone,
                TotalQuantity = (int)QuantityNumeric.Value,
                ReservedQuantity = selected.ReservedQuantity,
                UnitPrice = selected.UnitPrice
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
