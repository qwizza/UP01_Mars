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
    public partial class ReceiptItemEditForm : Form
    {
        public WarehouseItem EditedItem { get; private set; }

        private readonly List<WarehouseItem> _stockList;

        public ReceiptItemEditForm(WarehouseItem item, List<WarehouseItem> currentStock)
        {
            InitializeComponent();

            _stockList = currentStock ?? new List<WarehouseItem>();
            EditedItem = item ?? new WarehouseItem();

            foreach (var stock in _stockList)
                NomenclatureComboBox.Items.Add(stock.NomenclatureName);

            if (item != null)
            {
                NomenclatureComboBox.Text = item.NomenclatureName;
                QuantityNumericUpDown.Value = item.TotalQuantity > 0 ? item.TotalQuantity : 1;
                UnitPriceNumericUpDown.Value = item.UnitPrice >= 0 ? item.UnitPrice : 0m;
            }
        }

        private void NomenclatureComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = NomenclatureComboBox.Text.Trim();
            var found = _stockList.FirstOrDefault(x => x.NomenclatureName.Equals(selectedName, StringComparison.OrdinalIgnoreCase));

            if (found != null)
            {
                UnitPriceNumericUpDown.Value = found.UnitPrice >= 0 ? found.UnitPrice : 0m;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomenclatureComboBox.Text))
            {
                MessageBox.Show("Выберите или введите номенклатуру.");
                return;
            }

            EditedItem.NomenclatureName = NomenclatureComboBox.Text.Trim();
            EditedItem.TotalQuantity = (int)QuantityNumericUpDown.Value;
            EditedItem.UnitPrice = UnitPriceNumericUpDown.Value;
            EditedItem.StorageZone = "Основной склад";

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
