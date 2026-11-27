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
    public partial class WarehouseReceiptForm : Form
    {
        private readonly List<WarehouseItem> _currentStock;
        public WarehouseItem ReceiptItem { get; private set; }

        public WarehouseReceiptForm(List<WarehouseItem> currentStock)
        {
            InitializeComponent();
            _currentStock = currentStock ?? new List<WarehouseItem>();

            LoadNomenclatureList();
        }
        private void LoadNomenclatureList()
        {
            NomenclatureComboBox.Items.Clear();
            foreach (var item in _currentStock)
            {
                NomenclatureComboBox.Items.Add(item.NomenclatureName);
            }

            if (NomenclatureComboBox.Items.Count > 0)
            {
                NomenclatureComboBox.SelectedIndex = 0;
            }
            else
            {
                CurrentQuantityTextBox.Text = "0 (новая позиция)";
            }
        }
        private void UpdateSelectedInfo()
        {
            string name = NomenclatureComboBox.Text.Trim();
            var existing = _currentStock.FirstOrDefault(
                x => string.Equals(x.NomenclatureName, name, StringComparison.OrdinalIgnoreCase));

            if (existing != null)
            {
                CurrentQuantityTextBox.Text = $"{existing.TotalQuantity} шт. (в резерве: {existing.ReservedQuantity})";
                UnitPriceNumericUpDown.Value = existing.UnitPrice >= 0 ? existing.UnitPrice : 0m;
            }
            else
            {
                CurrentQuantityTextBox.Text = "0 (новая позиция)";
            }
        }
        private void NomenclatureComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedInfo();
        }

        private void NomenclatureComboBox_TextChanged(object sender, EventArgs e)
        {
            UpdateSelectedInfo();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = NomenclatureComboBox.Text.Trim();
            int quantity = (int)QuantityNumericUpDown.Value;
            decimal unitPrice = UnitPriceNumericUpDown.Value;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Необходимо указать наименование номенклатуры.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            if (quantity <= 0)
            {
                MessageBox.Show("Количество поступления должно быть больше нуля.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            ReceiptItem = new WarehouseItem
            {
                NomenclatureName = name,
                StorageZone = "Основной склад",
                TotalQuantity = quantity,
                UnitPrice = unitPrice
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
