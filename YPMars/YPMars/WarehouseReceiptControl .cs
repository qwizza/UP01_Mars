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
using YPMarsLib.Models;
using YPMarsLib.Services;

namespace YPMars
{
    public partial class WarehouseReceiptControl : UserControl
    {
        private List<WarehouseItem> _currentStock;
        private List<WarehouseItem> _itemsToReceipt = new List<WarehouseItem>();

        private WarehouseModel _model;
        private User _currentUser;
        private Action _onSuccess;

        public WarehouseReceiptControl()
        {
            InitializeComponent();
        }

        public void Initialize(WarehouseModel model, User currentUser, Action onSuccess)
        {
            _model = model;
            _currentUser = currentUser;
            _onSuccess = onSuccess;
            LoadNomenclatureList();
            RefreshGrid();
        }

        private void LoadNomenclatureList()
        {
            _currentStock = _model.Items ?? new List<WarehouseItem>();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using (var form = new ReceiptItemEditForm(new WarehouseItem(), _currentStock))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var newItem = form.EditedItem;

                    var existingItem = _itemsToReceipt.FirstOrDefault(x =>
                        x.NomenclatureName.Equals(newItem.NomenclatureName, StringComparison.OrdinalIgnoreCase));

                    if (existingItem != null)
                    {
                        existingItem.TotalQuantity += newItem.TotalQuantity;

                        existingItem.UnitPrice = newItem.UnitPrice;
                    }
                    else
                    {
                        _itemsToReceipt.Add(newItem);
                    }

                    RefreshGrid();
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (ReceiptDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выделите строку для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int index = ReceiptDataGridView.SelectedRows[0].Index;
            if (index >= 0 && index < _itemsToReceipt.Count)
            {
                var item = _itemsToReceipt[index];
                using (var form = new ReceiptItemEditForm(item, _currentStock))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        var duplicate = _itemsToReceipt.FirstOrDefault(x =>
                            x != item &&
                            x.NomenclatureName.Equals(item.NomenclatureName, StringComparison.OrdinalIgnoreCase));

                        if (duplicate != null)
                        {
                            duplicate.TotalQuantity += item.TotalQuantity;
                            _itemsToReceipt.Remove(item); 
                        }

                        RefreshGrid();
                    }
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ReceiptDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выделите строку для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int index = ReceiptDataGridView.SelectedRows[0].Index;
            if (index >= 0 && index < _itemsToReceipt.Count)
            {
                var itemToDelete = _itemsToReceipt[index];

                var result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить позицию \"{itemToDelete.NomenclatureName}\" из списка?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _itemsToReceipt.RemoveAt(index);
                    RefreshGrid();
                }
            }
        }

        private void RefreshGrid()
        {
            ReceiptDataGridView.Rows.Clear();
            ReceiptDataGridView.Columns.Clear();

            ReceiptDataGridView.Columns.Add("NomenclatureName", "Номенклатура");
            ReceiptDataGridView.Columns.Add("TotalQuantity", "Количество");
            ReceiptDataGridView.Columns.Add("UnitPrice", "Цена за ед.");
            ReceiptDataGridView.Columns.Add("TotalCost", "Сумма");

            ReceiptDataGridView.Columns["NomenclatureName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ReceiptDataGridView.Columns["TotalQuantity"].Width = 100;
            ReceiptDataGridView.Columns["UnitPrice"].Width = 120;
            ReceiptDataGridView.Columns["UnitPrice"].DefaultCellStyle.Format = "N2";
            ReceiptDataGridView.Columns["TotalCost"].Width = 120;
            ReceiptDataGridView.Columns["TotalCost"].DefaultCellStyle.Format = "N2";

            foreach (var item in _itemsToReceipt)
            {
                ReceiptDataGridView.Rows.Add(item.NomenclatureName, item.TotalQuantity, item.UnitPrice, item.TotalCost);
            }
            ReceiptDataGridView.ClearSelection();
        }

        private void SaveAllButton_Click(object sender, EventArgs e)
        {
            if (_itemsToReceipt.Count == 0) { MessageBox.Show("Список пуст."); return; }
            int successCount = 0;

            foreach (var item in _itemsToReceipt)
            {
                if (_model.RegisterReceipt(item, out string error)) successCount++;
                else MessageBox.Show($"Ошибка для {item.NomenclatureName}: {error}");
            }

            if (successCount > 0)
            {
                MessageBox.Show($"Успешно оприходовано {successCount} позиций!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _itemsToReceipt.Clear();
                RefreshGrid();
                _onSuccess?.Invoke();
                LoadNomenclatureList();
            }
        }

        private void ClearListButton_Click(object sender, EventArgs e)
        {
            if (_itemsToReceipt.Count == 0)
            {
                MessageBox.Show("Список уже пуст.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                "Вы уверены, что хотите полностью очистить список добавленных товаров?",
                "Подтверждение очистки",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _itemsToReceipt.Clear();
                RefreshGrid();
            }
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            if (_itemsToReceipt.Count == 0)
            {
                MessageBox.Show("Список товаров пуст. Добавьте товары перед формированием акта.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Документ Word (*.docx)|*.docx";
                dialog.FileName = $"Акт_приемки_{DateTime.Now:yyyyMMdd_HHmm}.docx";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var generator = new WarehouseReceiptReportGenerator();
                    string userName = _currentUser?.FullName ?? _currentUser?.Login ?? "";

                    string error = generator.GenerateWord(_itemsToReceipt, dialog.FileName, userName);

                    if (string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show("Акт приемки успешно сохранён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(error, "Ошибка экспорта", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
