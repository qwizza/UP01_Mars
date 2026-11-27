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
    public partial class WarehouseItemEditForm : Form
    {
        public string NewStorageZone { get; private set; }
        public decimal NewUnitPrice { get; private set; }
        public int NewReservedQuantity { get; private set; }

        public WarehouseItemEditForm(WarehouseItem item, List<string> storageZones)
        {
            InitializeComponent();

            this.Text = "Редактирование позиции на складе";

            NomenclatureTextBox.Text = item.NomenclatureName;
            NomenclatureTextBox.ReadOnly = true;

            StorageZoneComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            StorageZoneComboBox.Items.Clear();
            if (storageZones != null)
            {
                foreach (var zone in storageZones)
                    StorageZoneComboBox.Items.Add(zone);
            }

            if (!string.IsNullOrWhiteSpace(item.StorageZone) && StorageZoneComboBox.Items.Contains(item.StorageZone))
                StorageZoneComboBox.SelectedItem = item.StorageZone;
            else if (StorageZoneComboBox.Items.Count > 0)
                StorageZoneComboBox.SelectedIndex = 0;

            UnitPriceNumeric.DecimalPlaces = 2;
            UnitPriceNumeric.Minimum = 0;
            UnitPriceNumeric.Maximum = 100_000_000;
            UnitPriceNumeric.Value = item.UnitPrice >= 0 ? item.UnitPrice : 0m;

            StockInfoLabel.Text = $"Всего: {item.TotalQuantity} шт. | В резерве: {item.ReservedQuantity} шт. | Доступно: {item.AvailableQuantity} шт.";

            lblReserve.Text = "В резерве (шт.):";
            ReserveNumeric.Minimum = 0;
            ReserveNumeric.Maximum = Math.Max(0, item.TotalQuantity);
            ReserveNumeric.Value = Math.Min(Math.Max(0, item.ReservedQuantity), ReserveNumeric.Maximum);
            ReserveNumeric.Enabled = item.TotalQuantity > 0;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (StorageZoneComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите зону хранения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NewStorageZone = StorageZoneComboBox.SelectedItem.ToString();
            NewUnitPrice = UnitPriceNumeric.Value;
            NewReservedQuantity = (int)ReserveNumeric.Value;

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
