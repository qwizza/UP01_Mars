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
    public partial class ItemEditForm : Form
    {
        public OrderItem Item { get; private set; }

        private readonly Dictionary<string, decimal> nomenclaturePrices_;

        public ItemEditForm(Dictionary<string, decimal> nomenclaturePrices)
        {
            InitializeComponent();
            nomenclaturePrices_ = nomenclaturePrices ?? new Dictionary<string, decimal>();

            UnitPriceTextBox.ReadOnly = true;
            NomenclatureComboBox.Enabled = true;

            LoadNomenclature();
        }

        public ItemEditForm(Dictionary<string, decimal> nomenclaturePrices, OrderItem existingItem)
            : this(nomenclaturePrices)
        {
            if (existingItem != null)
            {
                this.Text = "Редактирование позиции";

                NomenclatureComboBox.Text = existingItem.NomenclatureName;
                NomenclatureComboBox.Enabled = false;

                QuantityNumericUpDown.Value = existingItem.Quantity > 0 ? existingItem.Quantity : 1;
                UnitPriceTextBox.Text = existingItem.UnitPrice.ToString("N2");

                Item = existingItem;
            }
        }

        private void LoadNomenclature()
        {
            NomenclatureComboBox.Items.Clear();
            foreach (var kvp in nomenclaturePrices_)
            {
                NomenclatureComboBox.Items.Add(kvp.Key);
            }

            if (NomenclatureComboBox.Items.Count > 0 && string.IsNullOrEmpty(NomenclatureComboBox.Text))
            {
                NomenclatureComboBox.SelectedIndex = 0;
            }
        }

        private void NomenclatureComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NomenclatureComboBox.SelectedItem != null)
            {
                string selectedName = NomenclatureComboBox.SelectedItem.ToString();
                if (nomenclaturePrices_.ContainsKey(selectedName))
                {
                    UnitPriceTextBox.Text = nomenclaturePrices_[selectedName].ToString("N2");
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomenclatureComboBox.Text))
            {
                MessageBox.Show("Необходимо выбрать номенклатуру.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            if (QuantityNumericUpDown.Value <= 0)
            {
                MessageBox.Show("Количество должно быть больше нуля.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            string nomenclatureName = NomenclatureComboBox.Text;
            decimal unitPrice = decimal.TryParse(UnitPriceTextBox.Text, out var price) ? price : 0m;

            if (unitPrice == 0 && nomenclaturePrices_.ContainsKey(nomenclatureName))
            {
                unitPrice = nomenclaturePrices_[nomenclatureName];
            }

            Item = new OrderItem
            {
                NomenclatureName = nomenclatureName,
                Quantity = (int)QuantityNumericUpDown.Value,
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