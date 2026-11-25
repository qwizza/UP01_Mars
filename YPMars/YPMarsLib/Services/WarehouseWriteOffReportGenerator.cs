using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YPMarsLib.Models;

namespace YPMarsLib.Services
{
    public class WarehouseWriteOffReportGenerator
    {
        public string Validate(List<WarehouseWriteOffRecord> records, WarehouseWriteOffFilter filter)
        {
            if (records == null)
                return "Не переданы записи для формирования отчёта.";
            if (filter == null)
                return "Не задан период отчёта.";
            if (filter.StartDate > filter.EndDate)
                return "Дата начала периода не может быть больше даты окончания.";
            if (records.Count == 0)
                return "Нет данных для формирования отчёта.";
            return string.Empty;
        }

        public string GenerateWord(List<WarehouseWriteOffRecord> records, WarehouseWriteOffFilter filter, string filePath)
        {
            string validation = Validate(records, filter);
            if (!string.IsNullOrEmpty(validation)) return validation;

            if (string.IsNullOrWhiteSpace(filePath))
                return "Не указан путь для сохранения файла.";

            try
            {
                using (var doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                {
                    var mainPart = doc.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    var body = new Body();

                    body.Append(CreateParagraph("Отчёт по списаниям товаров со склада", bold: true, size: 32));
                    body.Append(CreateParagraph($"Период: {filter.StartDate:dd.MM.yyyy} — {filter.EndDate:dd.MM.yyyy}"));
                    body.Append(CreateParagraph($"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}"));
                    body.Append(CreateParagraph(string.Empty));

                    body.Append(CreateTable(records));

                    decimal totalCost = records.Sum(r => r.TotalPrice);
                    int totalQty = records.Sum(r => r.Quantity);

                    body.Append(CreateParagraph(string.Empty));
                    body.Append(CreateParagraph($"Всего строк: {records.Count}. " +
                                                $"Суммарное количество: {totalQty} шт. " +
                                                $"Суммарная стоимость: {totalCost:N2} руб.", bold: true));

                    mainPart.Document.Append(body);
                    mainPart.Document.Save();
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Ошибка сохранения отчёта: " + ex.Message;
            }
        }

        private static Paragraph CreateParagraph(string text, bool bold = false, int size = 24)
        {
            var runProperties = new RunProperties(
                new RunFonts { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" },
                new FontSize { Val = size.ToString() }
            );

            if (bold) runProperties.Append(new Bold());

            var paragraphProperties = new ParagraphProperties(
                new Justification { Val = JustificationValues.Center },
                new SpacingBetweenLines { After = "120" } 
            );

            var run = new Run(runProperties, new Text(text) { Space = SpaceProcessingModeValues.Preserve });
            return new Paragraph(paragraphProperties, run);
        }

        private static Table CreateTable(List<WarehouseWriteOffRecord> records)
        {
            var table = new Table();

            var tableProperties = new TableProperties(
                new TableWidth { Width = "5000", Type = TableWidthUnitValues.Pct },
                new TableBorders(
                    new TopBorder { Val = BorderValues.Single, Size = 4, Color = "000000" },
                    new BottomBorder { Val = BorderValues.Single, Size = 4, Color = "000000" },
                    new LeftBorder { Val = BorderValues.Single, Size = 4, Color = "000000" },
                    new RightBorder { Val = BorderValues.Single, Size = 4, Color = "000000" },
                    new InsideHorizontalBorder { Val = BorderValues.Single, Size = 4, Color = "000000" },
                    new InsideVerticalBorder { Val = BorderValues.Single, Size = 4, Color = "000000" }
                )
            );

            table.AppendChild(tableProperties);

            table.AppendChild(CreateHeaderRow());

            foreach (var r in records)
            {
                var row = new TableRow();
                row.Append(CreateCell(r.WriteOffDate.ToString("dd.MM.yyyy HH:mm")));
                row.Append(CreateCell(r.NomenclatureName));
                row.Append(CreateCell(r.Quantity.ToString()));
                row.Append(CreateCell(r.UnitPrice.ToString("N2")));
                row.Append(CreateCell(r.TotalPrice.ToString("N2")));
                row.Append(CreateCell(r.UserName));
                table.Append(row);
            }
            return table;
        }

        private static TableRow CreateHeaderRow()
        {
            var row = new TableRow();
            row.Append(CreateCell("Дата списания", bold: true));
            row.Append(CreateCell("Наименование", bold: true));
            row.Append(CreateCell("Кол-во", bold: true));
            row.Append(CreateCell("Цена за ед.", bold: true));
            row.Append(CreateCell("Сумма", bold: true));
            row.Append(CreateCell("Пользователь", bold: true));
            return row;
        }

        private static TableCell CreateCell(string text, bool bold = false)
        {
            var runProperties = new RunProperties(
                new RunFonts { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" },
                new FontSize { Val = "24" } 
            );

            if (bold) runProperties.Append(new Bold());

            var paragraphProperties = new ParagraphProperties(
                new Justification { Val = JustificationValues.Center } 
            );

            var run = new Run(runProperties, new Text(text ?? string.Empty) { Space = SpaceProcessingModeValues.Preserve });

            return new TableCell(new Paragraph(paragraphProperties, run));
        }
    }
}
