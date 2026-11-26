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
            QuantityNumeric.ValueChanged += (s, e) => UpdateTotal();
            NomenclatureComboBox.SelectedIndexChanged += (s, e) => OnNomenclatureChanged();
        }

        public void Initialize(WarehouseModel model, User currentUser, Action onSuccess)
        {
            _model = model;
            _currentUser = currentUser;
            _onSuccess = onSuccess;

            _items = _model.Items ?? new List<WarehouseItem>();
            NomenclatureComboBox.DataSource = _items;
            NomenclatureComboBox.DisplayMember = nameof(WarehouseItem.NomenclatureName);
            NomenclatureComboBox.SelectedIndex = _items.Count > 0 ? 0 : -1;
            OnNomenclatureChanged();
        }

        private void UpdateTotal()
        {
            decimal price = decimal.TryParse(UnitPriceTextBox.Text, out var p) ? p : 0m;
            TotalSumLabel.Text = $"Сумма: {(price * QuantityNumeric.Value):N2} руб.";
        }

        private void OnNomenclatureChanged()
        {
            if (NomenclatureComboBox.SelectedItem is WarehouseItem item)
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
            if (!(NomenclatureComboBox.SelectedItem is WarehouseItem selected))
            {
                MessageBox.Show("Необходимо выбрать номенклатуру.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
