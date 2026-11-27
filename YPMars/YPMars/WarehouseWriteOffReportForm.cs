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
    public partial class WarehouseWriteOffReportForm : Form
    {
        private readonly WarehouseModel _model;
        private readonly WarehouseWriteOffReportGenerator _generator = new WarehouseWriteOffReportGenerator();
        private List<WarehouseWriteOffRecord> _records = new List<WarehouseWriteOffRecord>();
        private WarehouseWriteOffFilter _lastFilter;
        private string _currentUserName;

        public WarehouseWriteOffReportForm(WarehouseModel model, string userName = "")
        {
            InitializeComponent();
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _currentUserName = userName;

            StartDatePicker.Value = DateTime.Now.AddDays(-30);
            EndDatePicker.Value = DateTime.Now;

            SetupGrid();
            UpdateSummary();
        }

        private void SetupGrid()
        {
            ReportDataGridView.AutoGenerateColumns = false;
            ReportDataGridView.Columns.Clear();

            ReportDataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Дата списания", DataPropertyName = "WriteOffDate", Width = 150 });
            ReportDataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Наименование", DataPropertyName = "NomenclatureName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            ReportDataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Кол-во", DataPropertyName = "Quantity", Width = 80 });
            ReportDataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Цена за ед.", DataPropertyName = "UnitPrice", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            ReportDataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Сумма", DataPropertyName = "TotalPrice", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            ReportDataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Пользователь", DataPropertyName = "UserName", Width = 130 });

            ReportDataGridView.CellFormatting += ReportDataGridView_CellFormatting;
        }

        private void ReportDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime dt)
            {
                e.Value = dt.ToString("dd.MM.yyyy HH:mm");
                e.FormattingApplied = true;
            }
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            _lastFilter = new WarehouseWriteOffFilter
            {
                StartDate = StartDatePicker.Value.Date,
                EndDate = EndDatePicker.Value.Date.AddDays(1).AddTicks(-1)
            };

            _records = _model.GetWriteOffReport(_lastFilter, out string error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReportDataGridView.DataSource = null;
            ReportDataGridView.DataSource = _records;
            UpdateSummary();
        }

        private void UpdateSummary()
        {
            int count = _records.Count;
            int qty = _records.Sum(r => r.Quantity);
            decimal cost = _records.Sum(r => r.TotalPrice);
            SummaryLabel.Text = $"Всего строк: {count}. Суммарное количество: {qty} шт. Суммарная стоимость: {cost:N2} руб.";
        }

        private void ExportDocxButton_Click(object sender, EventArgs e)
        {
            if (_records.Count == 0 || _lastFilter == null)
            {
                MessageBox.Show("Нет данных для экспорта. Сформируйте отчёт.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Документ Word (*.docx)|*.docx";
                dialog.FileName = $"Списания_{DateTime.Now:yyyyMMdd_HHmm}.docx";
                if (dialog.ShowDialog() != DialogResult.OK) return;

                string error = _generator.GenerateWord(_records, _lastFilter, dialog.FileName, _currentUserName);
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error, "Ошибка экспорта", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Отчёт успешно сохранён.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e) => Close();

    }
}
