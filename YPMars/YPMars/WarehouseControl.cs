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
    public partial class WarehouseControl : UserControl
    {
        private const string AllZonesOption = "Все зоны";

        private WarehouseModel _warehouseModel;
        private User _currentUser;
        private bool _isUpdatingZones;

        public WarehouseControl()
        {
            InitializeComponent();
        }

        public void Initialize(WarehouseModel warehouseModel, User currentUser = null)
        {
            _warehouseModel = warehouseModel;
            _currentUser = currentUser;

            if (currentUser != null)
            {
                bool canManage = currentUser.Role == User.UserRole.Warehouser
                              || currentUser.Role == User.UserRole.SuperUser;

                ReportButton.Visible = canManage;
                EditButton.Visible = canManage;
            }

            LoadZoneFilter();
            LoadStock();
        }

        private void LoadZoneFilter()
        {
            if (_warehouseModel == null) return;

            string previousSelection = ZoneFilterComboBox.SelectedItem?.ToString();

            _isUpdatingZones = true;
            try
            {
                ZoneFilterComboBox.Items.Clear();
                ZoneFilterComboBox.Items.Add(AllZonesOption);

                var zones = _warehouseModel.GetStorageZones(out _);
                if (zones != null)
                {
                    foreach (var zone in zones)
                        ZoneFilterComboBox.Items.Add(zone);
                }

                if (!string.IsNullOrEmpty(previousSelection) && ZoneFilterComboBox.Items.Contains(previousSelection))
                    ZoneFilterComboBox.SelectedItem = previousSelection;
                else
                    ZoneFilterComboBox.SelectedIndex = 0;
            }
            finally
            {
                _isUpdatingZones = false;
            }
        }

        public void LoadStock()
        {
            if (_warehouseModel == null) return;

            var stock = _warehouseModel.GetStock(out string error);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WarehouseDataGridView.DataSource = stock;
                UpdateFooter(stock);
                return;
            }

            ApplyFilters();
        }

        private void ApplyFilters()
        {
            if (_warehouseModel == null) return;

            var allItems = _warehouseModel.Items;
            if (allItems == null) return;

            string searchText = SearchTextBox.Text.Trim().ToLower();
            string selectedZone = ZoneFilterComboBox.SelectedItem?.ToString();

            IEnumerable<WarehouseItem> query = allItems;

            if (!string.IsNullOrEmpty(selectedZone) && selectedZone != AllZonesOption)
            {
                query = query.Where(x => string.Equals(x.StorageZone, selectedZone, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(x => x.NomenclatureName != null && x.NomenclatureName.ToLower().Contains(searchText));
            }

            var filtered = query.ToList();
            WarehouseDataGridView.DataSource = filtered;

            if (WarehouseDataGridView.Columns["UnitPrice"] != null)
                WarehouseDataGridView.Columns["UnitPrice"].DefaultCellStyle.Format = "N2";
            if (WarehouseDataGridView.Columns["TotalCost"] != null)
                WarehouseDataGridView.Columns["TotalCost"].DefaultCellStyle.Format = "N2";

            UpdateFooter(filtered);
        }

        private void UpdateFooter(List<WarehouseItem> items)
        {
            decimal totalCost = _warehouseModel.CalculateTotalStockCost(items);
            int totalAvailable = _warehouseModel.CalculateTotalAvailableQuantity(items);
            int positionCount = items?.Count ?? 0;

            TotalCountLabel.Text = $"Всего позиций на складе: {positionCount}";
            TotalAvailableLabel.Text = $"Доступно к отгрузке: {totalAvailable} шт.";
            TotalSumLabel.Text = $"Общая стоимость: {totalCost:N2} руб.";
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadZoneFilter();
            LoadStock();
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            if (_warehouseModel == null) return;

            using (var form = new WarehouseWriteOffReportForm(_warehouseModel))
            {
                form.ShowDialog(this);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (_warehouseModel == null) return;

            if (WarehouseDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите позицию на складе для редактирования.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!(WarehouseDataGridView.SelectedRows[0].DataBoundItem is WarehouseItem selectedItem))
                return;

            var zones = _warehouseModel.GetStorageZones(out string zonesError);
            if (!string.IsNullOrEmpty(zonesError))
            {
                MessageBox.Show(zonesError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var form = new WarehouseItemEditForm(selectedItem, zones))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (_warehouseModel.UpdateItem(
                        selectedItem.NomenclatureName,
                        form.NewStorageZone,
                        form.NewUnitPrice,
                        form.NewReservedQuantity,
                        out string error))
                    {
                        MessageBox.Show("Данные позиции успешно обновлены!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStock();
                    }
                    else
                    {
                        MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ZoneFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isUpdatingZones) return;
            ApplyFilters();
        }
    }
}
