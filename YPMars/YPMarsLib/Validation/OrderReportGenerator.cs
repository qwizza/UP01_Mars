using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YPMarsLib.Models;

namespace YPMarsLib.Validation
{
    public class OrderReportGenerator
    {
        public string Validate(OrderReport report)
        {
            if (report == null) return "Отчет не сформирован";
            if (string.IsNullOrWhiteSpace(report.ContractNumber)) return "Не заполнен номер договора";
            if (string.IsNullOrWhiteSpace(report.CounterpartyName)) return "Не заполнены реквизиты контрагента";
            if (report.Items == null || report.Items.Count == 0) return "Невозможно сформировать отчёт: в заказе нет позиций";
            return string.Empty;
        }

        public string GenerateWord(OrderReport report, string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) return "Не указан путь для сохранения документа";
            string validation = Validate(report);
            if (!string.IsNullOrEmpty(validation)) return validation;

            try
            {
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());

                    // 1. Заголовок (Times New Roman, Bold, 16pt)
                    body.Append(CreateParagraph("Отчёт по заказу покупателя", true, 32));

                    // 2. Реквизиты договора
                    body.Append(CreateParagraph($"Номер договора: {report.ContractNumber}", false, 24, JustificationValues.Left));
                    body.Append(CreateParagraph($"Дата оформления: {report.OrderDate:dd.MM.yyyy}", false, 24, JustificationValues.Left));
                    body.Append(CreateParagraph($"Плановая дата отгрузки: {(report.PlannedShipmentDate.HasValue ? report.PlannedShipmentDate.Value.ToString("dd.MM.yyyy") : "—")}", false, 24, JustificationValues.Left));
                    body.Append(CreateParagraph($"Статус: {report.StatusText}", false, 24, JustificationValues.Left));
                    body.Append(CreateParagraph(" ", false, 24));

                    // 3. Реквизиты контрагента
                    body.Append(CreateParagraph("Контрагент:", true, 24, JustificationValues.Left));
                    body.Append(CreateParagraph($"Наименование: {report.CounterpartyName}", false, 24, JustificationValues.Left));
                    body.Append(CreateParagraph($"ИНН: {report.CounterpartyINN ?? "—"}", false, 24, JustificationValues.Left));
                    body.Append(CreateParagraph($"КПП: {report.CounterpartyKPP ?? "—"}", false, 24, JustificationValues.Left));
                    body.Append(CreateParagraph($"Адрес: {report.CounterpartyAddress ?? "—"}", false, 24, JustificationValues.Left));
                    body.Append(CreateParagraph(" ", false, 24));

                    // 4. Таблица позиций
                    Table table = CreateTable(report.Items);
                    body.Append(table);

                    // 5. Итог
                    body.Append(CreateParagraph(" ", false, 24));
                    body.Append(CreateParagraph($"Общее количество позиций: {report.PositionCount}", true, 24, JustificationValues.Left));
                    body.Append(CreateParagraph($"Итоговая сумма: {report.TotalAmount:N2} руб.", true, 24, JustificationValues.Left));

                    // 6. Подпись
                    body.Append(CreateParagraph(" ", false, 24));
                    body.Append(CreateParagraph($"Дата формирования: {report.GeneratedDate:dd.MM.yyyy HH:mm}", false, 24, JustificationValues.Left));
                    body.Append(CreateParagraph($"Ответственный: {report.ResponsibleEmployee ?? "—"}", false, 24, JustificationValues.Left));

                    mainPart.Document.Save();
                }
                return string.Empty;
            }
            catch (UnauthorizedAccessException)
            {
                return "Нет прав на запись файла по указанному пути";
            }
            catch (Exception ex)
            {
                return "Ошибка формирования отчета: " + ex.Message;
            }
        }

        // Вспомогательный метод для создания абзацев (со шрифтом Times New Roman)
        private Paragraph CreateParagraph(string text, bool isBold = false, int size = 24)
        {
            return CreateParagraph(text, isBold, size, JustificationValues.Center);
        }

        // 2. Основной метод (без значения по умолчанию)
        private Paragraph CreateParagraph(string text, bool isBold, int size, JustificationValues align)
        {
            var runProperties = new RunProperties(
                new RunFonts { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" },
                new FontSize { Val = size.ToString() }
            );

            if (isBold) runProperties.Append(new Bold());

            var paragraphProperties = new ParagraphProperties(
                new Justification { Val = align },
                new SpacingBetweenLines { After = "120" }
            );

            var run = new Run(runProperties, new Text(text) { Space = SpaceProcessingModeValues.Preserve });
            return new Paragraph(paragraphProperties, run);
        }

        // Вспомогательный метод для создания таблицы
        private Table CreateTable(List<OrderItem> items)
        {
            var table = new Table();
            table.AppendChild(new TableProperties(
                new TableWidth { Width = "5000", Type = TableWidthUnitValues.Pct },
                new TableBorders(
                    new TopBorder { Val = BorderValues.Single, Size = 4 },
                    new BottomBorder { Val = BorderValues.Single, Size = 4 },
                    new LeftBorder { Val = BorderValues.Single, Size = 4 },
                    new RightBorder { Val = BorderValues.Single, Size = 4 },
                    new InsideHorizontalBorder { Val = BorderValues.Single, Size = 4 },
                    new InsideVerticalBorder { Val = BorderValues.Single, Size = 4 }
                )
            ));

            // Шапка таблицы
            TableRow headerRow = new TableRow();
            headerRow.Append(
                CreateCell("№", true),
                CreateCell("Наименование", true),
                CreateCell("Кол-во", true),
                CreateCell("Цена", true),
                CreateCell("Сумма", true)
            );
            table.Append(headerRow);

            // Данные
            int i = 1;
            foreach (var item in items)
            {
                TableRow row = new TableRow();
                row.Append(
                    CreateCell(i.ToString()),
                    CreateCell(item.NomenclatureName),
                    CreateCell(item.Quantity.ToString()),
                    CreateCell(item.UnitPrice.ToString("N2")),
                    CreateCell(item.TotalPrice.ToString("N2"))
                );
                table.Append(row);
                i++;
            }
            return table;
        }

        // Вспомогательный метод для ячеек (со шрифтом Times New Roman)
        private TableCell CreateCell(string text, bool isBold = false)
        {
            var runProperties = new RunProperties(
                new RunFonts { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" },
                new FontSize { Val = "22" } // 11pt
            );
            if (isBold) runProperties.Append(new Bold());

            var paragraphProperties = new ParagraphProperties(
                new Justification { Val = JustificationValues.Center }
            );

            var run = new Run(runProperties, new Text(text ?? string.Empty) { Space = SpaceProcessingModeValues.Preserve });
            return new TableCell(new Paragraph(paragraphProperties, run));
        }
    }
}
