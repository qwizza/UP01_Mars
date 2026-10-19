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
    public partial class OrderDetailsForm : Form
    {
        private readonly Order order_;
        private readonly OrderManager orderManager_;
        public OrderDetailsForm(Order order, OrderManager orderManager)
        {
            order_ = order;
            orderManager_ = orderManager;

            InitializeComponent();
            LoadOrderItems();
        }
        private void LoadOrderItems()
        {
            string error;
            var items = orderManager_.GetOrderItems(order_.ContractNumber, out error);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            order_.Items = items;
            ItemsDataGridView.DataSource = null;
            ItemsDataGridView.DataSource = order_.Items;

            UpdateSummary();
        }
        private void UpdateSummary()
        {
            if (order_.Items == null || order_.Items.Count == 0)
            {
                SummaryLabel.Text = "В заказе нет позиций. Итоговая сумма: 0,00 руб.";
            }
            else
            {
                decimal totalSum = 0;
                foreach (var item in order_.Items)
                {
                    totalSum += item.Quantity * item.UnitPrice;
                }
                SummaryLabel.Text = $"Всего позиций: {order_.Items.Count}. Итоговая сумма: {totalSum.ToString("N2")} руб.";
            }
        }

        private void AddItemButton_Click(object sender, EventArgs e)
        {
            var editForm = new ItemEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                string error;
                bool success = orderManager_.AddItemToOrder(order_.ContractNumber, editForm.Item, out error);

                if (success)
                {
                    LoadOrderItems();
                }
                else
                {
                    MessageBox.Show(error, "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void EditItemButton_Click(object sender, EventArgs e)
        {
            if (ItemsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите позицию для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedItem = ItemsDataGridView.SelectedRows[0].DataBoundItem as OrderItem;
            if (selectedItem == null) return;

            var editForm = new ItemEditForm(new OrderListRepository(), selectedItem);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                string error;
                selectedItem.Quantity = editForm.Item.Quantity;
                bool success = orderManager_.UpdateItemInOrder(order_.ContractNumber, selectedItem, out error);

                if (success)
                {
                    LoadOrderItems();
                }
                else
                {
                    MessageBox.Show(error, "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DeleteItemButton_Click(object sender, EventArgs e)
        {
            if (ItemsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите позицию для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedItem = ItemsDataGridView.SelectedRows[0].DataBoundItem as OrderItem;
            if (selectedItem == null) return;

            var confirmResult = MessageBox.Show($"Вы действительно хотите удалить позицию \"{selectedItem.NomenclatureName}\"?",
                                                "Подтверждение удаления",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                string error;
                bool success = orderManager_.DeleteItemFromOrder(order_.ContractNumber, selectedItem, out error);

                if (success)
                {
                    LoadOrderItems();
                }
                else
                {
                    MessageBox.Show(error, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
