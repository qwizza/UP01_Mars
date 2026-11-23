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
        private WarehouseModel _warehouseModel;

        public WarehouseControl()
        {
            InitializeComponent();
        }

        public void Initialize(WarehouseModel warehouseModel)
        {
            _warehouseModel = warehouseModel;
            LoadStock();
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

            WarehouseDataGridView.DataSource = stock;

            if (WarehouseDataGridView.Columns["UnitPrice"] != null)
                WarehouseDataGridView.Columns["UnitPrice"].DefaultCellStyle.Format = "N2";
            if (WarehouseDataGridView.Columns["TotalCost"] != null)
                WarehouseDataGridView.Columns["TotalCost"].DefaultCellStyle.Format = "N2";

            UpdateFooter(stock);
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
            LoadStock();
        }
    }
}
