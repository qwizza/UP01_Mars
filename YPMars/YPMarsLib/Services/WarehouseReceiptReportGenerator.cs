using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib.Services
{
    public class WarehouseReceiptReportGenerator
    {
        public string GenerateWord(List<WarehouseItem> items, string filePath, string currentUserName)
        {
            if (items == null || items.Count == 0) return "Нет данных для формирования отчёта.";
            if (string.IsNullOrWhiteSpace(filePath)) return "Не указан путь для сохранения файла.";

            try
            {
                using (var doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                {
                    var mainPart = doc.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    var body = new Body();

                    body.Append(CreateParagraph("АКТ ПРИЕМКИ ТОВАРОВ НА СКЛАД", bold: true, size: 32));
                    body.Append(CreateParagraph($"Организация: ООО «Завод МАРС»", size: 24));
                    body.Append(CreateParagraph("", size: 12));

                    body.Append(CreateTable(items));

                    decimal totalCost = items.Sum(i => i.TotalCost);
                    int totalQty = items.Sum(i => i.TotalQuantity);
                    body.Append(CreateParagraph("", size: 12));
                    body.Append(CreateParagraph($"Всего позиций: {items.Count}. Общее количество: {totalQty} шт. Суммарная стоимость: {totalCost:N2} руб.", bold: true, size: 24));

                    body.Append(CreateParagraph("", size: 12));
                    body.Append(CreateParagraph($"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}", size: 24));

                    body.Append(CreateParagraph("", size: 24));
                    body.Append(CreateSignatureBlock("Сдал (Поставщик)", ""));
                    body.Append(CreateParagraph("", size: 24));
                    body.Append(CreateSignatureBlock("Принял (Кладовщик)", currentUserName));

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
                new RunFonts { Ascii = "Times New Roman", HighAnsi = "Times New Roman" },
                new FontSize { Val = size.ToString() }
            );
            if (bold) runProperties.Append(new Bold());

            var paragraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Center });
            var run = new Run(runProperties, new Text(text) { Space = SpaceProcessingModeValues.Preserve });
            return new Paragraph(paragraphProperties, run);
        }

        private static Table CreateTable(List<WarehouseItem> items)
        {
            var table = new Table();
            table.AppendChild(new TableProperties(
                new TableWidth { Width = "5000", Type = TableWidthUnitValues.Pct },
                new TableJustification { Val = TableRowAlignmentValues.Center },
                new TableBorders(
                    new TopBorder { Val = BorderValues.Single, Size = 4, Color = "000000" },
                    new BottomBorder { Val = BorderValues.Single, Size = 4, Color = "000000" },
                    new LeftBorder { Val = BorderValues.Single, Size = 4, Color = "000000" },
                    new RightBorder { Val = BorderValues.Single, Size = 4, Color = "000000" },
                    new InsideHorizontalBorder { Val = BorderValues.Single, Size = 4, Color = "000000" },
                    new InsideVerticalBorder { Val = BorderValues.Single, Size = 4, Color = "000000" }
                )));

            var headerRow = new TableRow();
            headerRow.Append(CreateCell("№", bold: true));
            headerRow.Append(CreateCell("Наименование", bold: true));
            headerRow.Append(CreateCell("Кол-во", bold: true));
            headerRow.Append(CreateCell("Цена за ед.", bold: true));
            headerRow.Append(CreateCell("Сумма", bold: true));
            table.Append(headerRow);

            int counter = 1;
            foreach (var r in items)
            {
                var row = new TableRow();
                row.Append(CreateCell(counter.ToString()));
                row.Append(CreateCell(r.NomenclatureName));
                row.Append(CreateCell(r.TotalQuantity.ToString()));
                row.Append(CreateCell(r.UnitPrice.ToString("N2")));
                row.Append(CreateCell(r.TotalCost.ToString("N2")));
                table.Append(row);
                counter++;
            }
            return table;
        }

        private static TableCell CreateCell(string text, bool bold = false)
        {
            var runProperties = new RunProperties(
                new RunFonts { Ascii = "Times New Roman", HighAnsi = "Times New Roman" },
                new FontSize { Val = "22" }
            );
            if (bold) runProperties.Append(new Bold());

            var paragraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Center });
            var run = new Run(runProperties, new Text(text ?? string.Empty) { Space = SpaceProcessingModeValues.Preserve });
            return new TableCell(new Paragraph(paragraphProperties, run));
        }

        private static Paragraph CreateSignatureBlock(string role, string fio)
        {
            var paragraph = new Paragraph();

            var paragraphProperties = new ParagraphProperties(
                new Tabs(new TabStop { Val = TabStopValues.Left, Position = 4000 })
            );

            paragraph.Append(paragraphProperties);

            paragraph.Append(new Run(
                new RunProperties(new RunFonts { Ascii = "Times New Roman", HighAnsi = "Times New Roman" }, new FontSize { Val = "24" }),
                new Text(role) { Space = SpaceProcessingModeValues.Preserve }
            ));

            paragraph.Append(new Run(new TabChar()));

            string line = "_________________";
            string finalText = string.IsNullOrWhiteSpace(fio) ? $"{line} _______________" : $"{line} {fio}";

            paragraph.Append(new Run(
                new RunProperties(new RunFonts { Ascii = "Times New Roman", HighAnsi = "Times New Roman" }, new FontSize { Val = "24" }),
                new Text(finalText) { Space = SpaceProcessingModeValues.Preserve }
            ));

            return paragraph;
        }
    }
}
