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
    public partial class WarehouseReceiptControl : UserControl
    {
        private List<WarehouseItem> _currentStock;
        private WarehouseModel _model;
        private Action _onSuccess;

        public WarehouseReceiptControl()
        {
            InitializeComponent();
        }
        public void Initialize(WarehouseModel model, Action onSuccess)
        {
            _model = model;
            _onSuccess = onSuccess;
            LoadNomenclatureList();
        }

        private void LoadNomenclatureList()
        {
            NomenclatureComboBox.Items.Clear();
            _currentStock = _model.Items ?? new List<WarehouseItem>();

            foreach (var item in _currentStock)
            {
                NomenclatureComboBox.Items.Add(item.NomenclatureName);
            }

            if (NomenclatureComboBox.Items.Count > 0)
                NomenclatureComboBox.SelectedIndex = 0;
            else
                CurrentQuantityTextBox.Text = "0 (новая позиция)";
        }

        private void NomenclatureComboBox_SelectedIndexChanged(object sender, EventArgs e)
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = NomenclatureComboBox.Text.Trim();
            int quantity = (int)QuantityNumericUpDown.Value;
            decimal unitPrice = UnitPriceNumericUpDown.Value;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Необходимо указать наименование номенклатуры.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (quantity <= 0)
            {
                MessageBox.Show("Количество поступления должно быть больше нуля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var receiptItem = new WarehouseItem
            {
                NomenclatureName = name,
                StorageZone = "Основной склад",
                TotalQuantity = quantity,
                UnitPrice = unitPrice
            };

            if (_model.RegisterReceipt(receiptItem, out string error))
            {
                MessageBox.Show("Поступление успешно оформлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NomenclatureComboBox.Text = "";
                QuantityNumericUpDown.Value = 1;
                _onSuccess?.Invoke();
                LoadNomenclatureList();
            }
            else
            {
                MessageBox.Show(error, "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
