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
    }
}
