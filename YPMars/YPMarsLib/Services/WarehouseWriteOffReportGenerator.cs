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
            if (records == null) return "Не переданы записи для формирования отчёта.";
            if (filter == null) return "Не задан период отчёта.";
            if (filter.StartDate > filter.EndDate) return "Дата начала периода не может быть больше даты окончания.";
            if (records.Count == 0) return "Нет данных для формирования отчёта.";
            return string.Empty;
        }

        public string GenerateWord(List<WarehouseWriteOffRecord> records, WarehouseWriteOffFilter filter, string filePath, string currentUserName)
        {
            string validation = Validate(records, filter);
            if (!string.IsNullOrEmpty(validation)) return validation;
            if (string.IsNullOrWhiteSpace(filePath)) return "Не указан путь для сохранения файла.";

            try
            {
                using (var doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                {
                    var mainPart = doc.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    var body = new Body();

                    // 1. Заголовок
                    body.Append(CreateParagraph("ОТЧЁТ ПО СПИСАНИЯМ ТОВАРОВ СО СКЛАДА", bold: true, size: 32));
                    body.Append(CreateParagraph($"Период: {filter.StartDate:dd.MM.yyyy} — {filter.EndDate:dd.MM.yyyy}", size: 24));
                    body.Append(CreateParagraph($"Организация: ООО «Завод МАРС»", size: 24));
                    body.Append(CreateParagraph("", size: 12)); // Отступ

                    // 2. Таблица
                    body.Append(CreateTable(records));

                    // 3. Итоги
                    decimal totalCost = records.Sum(r => r.TotalPrice);
                    int totalQty = records.Sum(r => r.Quantity);
                    body.Append(CreateParagraph("", size: 12)); // Отступ
                    body.Append(CreateParagraph($"Всего строк: {records.Count}. Суммарное количество: {totalQty} шт. Суммарная стоимость: {totalCost:N2} руб.", bold: true, size: 24));

                    // 4. Дата формирования документа
                    body.Append(CreateParagraph("", size: 12)); // Отступ
                    body.Append(CreateParagraph($"Дата формирования документа: {DateTime.Now:dd.MM.yyyy HH:mm}", size: 24));

                    // 5. Подписи
                    body.Append(CreateParagraph("", size: 24));
                    body.Append(CreateSignatureTable(currentUserName));

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
            return CreateParagraph(text, bold, size, JustificationValues.Center);
        }

        // Основной метод (без значения по умолчанию для align)
        private static Paragraph CreateParagraph(string text, bool bold, int size, JustificationValues align)
        {
            var runProperties = new RunProperties(
                new RunFonts { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" },
                new FontSize { Val = size.ToString() }
            );

            if (bold) runProperties.Append(new Bold());

            var paragraphProperties = new ParagraphProperties(
                new Justification { Val = align },
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
                new TableJustification { Val = TableRowAlignmentValues.Center },
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

            // Заголовки столбцов (без "Пользователя")
            var headerRow = new TableRow();
            headerRow.Append(CreateCell("Дата списания", bold: true));
            headerRow.Append(CreateCell("Наименование", bold: true));
            headerRow.Append(CreateCell("Кол-во", bold: true));
            headerRow.Append(CreateCell("Цена за ед.", bold: true));
            headerRow.Append(CreateCell("Сумма", bold: true));
            table.Append(headerRow);

            // Строки данных
            foreach (var r in records)
            {
                var row = new TableRow();
                row.Append(CreateCell(r.WriteOffDate.ToString("dd.MM.yyyy HH:mm")));
                row.Append(CreateCell(r.NomenclatureName));
                row.Append(CreateCell(r.Quantity.ToString()));
                row.Append(CreateCell(r.UnitPrice.ToString("N2")));
                row.Append(CreateCell(r.TotalPrice.ToString("N2")));
                // Столбец с пользователем удален
                table.Append(row);
            }
            return table;
        }

        private static TableCell CreateCell(string text, bool bold = false)
        {
            var runProperties = new RunProperties(
                new RunFonts { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" },
                new FontSize { Val = "22" } // 11pt
            );
            if (bold) runProperties.Append(new Bold());

            var paragraphProperties = new ParagraphProperties(
                new Justification { Val = JustificationValues.Center }
            );

            var run = new Run(runProperties, new Text(text ?? string.Empty) { Space = SpaceProcessingModeValues.Preserve });
            return new TableCell(new Paragraph(paragraphProperties, run));
        }

        private static Table CreateSignatureTable(string currentUserName)
        {
            var table = new Table();
            table.AppendChild(new TableProperties(new TableWidth { Width = "5000", Type = TableWidthUnitValues.Pct }));

            // Строка 1: Должность и подпись
            var row1 = new TableRow();
            row1.Append(CreateSignatureCell("Кладовщик", widthPct: "30"));
            row1.Append(CreateSignatureCell("_________________", widthPct: "20")); // Место для подписи
            row1.Append(CreateSignatureCell($"{currentUserName ?? "_____________"}", widthPct: "30")); // Расшифровка

            // Строка 2: Пустая (для отступа)
            var row2 = new TableRow();
            row2.Append(CreateSignatureCell("", widthPct: "30"));
            row2.Append(CreateSignatureCell("", widthPct: "20"));
            row2.Append(CreateSignatureCell("", widthPct: "30"));

            // Строка 3: Руководитель
            var row3 = new TableRow();
            row3.Append(CreateSignatureCell("Руководитель", widthPct: "30"));
            row3.Append(CreateSignatureCell("_________________", widthPct: "20"));
            row3.Append(CreateSignatureCell("_________________", widthPct: "30"));

            table.Append(row1);
            table.Append(row2);
            table.Append(row3);

            return table;
        }

        private static TableCell CreateSignatureCell(string text, string widthPct)
        {
            var tcPr = new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = widthPct });
            var paragraph = CreateParagraph(text, bold: false, size: 24, align: JustificationValues.Left);
            return new TableCell(tcPr, paragraph);
        }
    }
}
