using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
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

                    // 1. Заголовок
                    Paragraph title = new Paragraph(new ParagraphProperties(new Justification() { Val = JustificationValues.Center }));
                    Run titleRun = new Run(new Text("Отчёт по заказу покупателя"));
                    titleRun.RunProperties = new RunProperties(new Bold(), new FontSize() { Val = "32" }); // 16pt
                    title.Append(titleRun);
                    body.AppendChild(title);

                    // 2. Реквизиты договора
                    body.AppendChild(new Paragraph(new Run(new Text($"Номер договора: {report.ContractNumber}"))));
                    body.AppendChild(new Paragraph(new Run(new Text($"Дата оформления: {report.OrderDate:dd.MM.yyyy}"))));
                    body.AppendChild(new Paragraph(new Run(new Text($"Плановая дата отгрузки: {(report.PlannedShipmentDate.HasValue ? report.PlannedShipmentDate.Value.ToString("dd.MM.yyyy") : "—")}"))));
                    body.AppendChild(new Paragraph(new Run(new Text($"Статус: {report.StatusText}"))));
                    body.AppendChild(new Paragraph(new Run(new Text(" "))));

                    // 3. Реквизиты контрагента
                    body.AppendChild(new Paragraph(new Run(new Text("Контрагент:")) { RunProperties = new RunProperties(new Bold()) }));
                    body.AppendChild(new Paragraph(new Run(new Text($"Наименование: {report.CounterpartyName}"))));
                    body.AppendChild(new Paragraph(new Run(new Text($"ИНН: {report.CounterpartyINN ?? "—"}"))));
                    body.AppendChild(new Paragraph(new Run(new Text($"КПП: {report.CounterpartyKPP ?? "—"}"))));
                    body.AppendChild(new Paragraph(new Run(new Text($"Адрес: {report.CounterpartyAddress ?? "—"}"))));
                    body.AppendChild(new Paragraph(new Run(new Text(" "))));

                    // 4. Таблица позиций
                    Table table = new Table();
                    table.AppendChild(new TableProperties(new TableBorders(
                        new TopBorder { Val = BorderValues.Single, Size = 4 },
                        new BottomBorder { Val = BorderValues.Single, Size = 4 },
                        new LeftBorder { Val = BorderValues.Single, Size = 4 },
                        new RightBorder { Val = BorderValues.Single, Size = 4 },
                        new InsideHorizontalBorder { Val = BorderValues.Single, Size = 4 },
                        new InsideVerticalBorder { Val = BorderValues.Single, Size = 4 }
                    )));

                    // Шапка таблицы
                    TableRow headerRow = new TableRow();
                    headerRow.Append(CreateCell("№", true), CreateCell("Наименование", true), CreateCell("Кол-во", true), CreateCell("Цена", true), CreateCell("Сумма", true));
                    table.AppendChild(headerRow);

                    // Данные
                    int i = 1;
                    foreach (var item in report.Items)
                    {
                        TableRow row = new TableRow();
                        row.Append(
                            CreateCell(i.ToString()),
                            CreateCell(item.NomenclatureName),
                            CreateCell(item.Quantity.ToString()),
                            CreateCell(item.UnitPrice.ToString("N2")),
                            CreateCell(item.TotalPrice.ToString("N2"))
                        );
                        table.AppendChild(row);
                        i++;
                    }
                    body.AppendChild(table);

                    // 5. Итог
                    body.AppendChild(new Paragraph(new Run(new Text(" "))));
                    Paragraph totalP = new Paragraph();
                    Run totalRun = new Run(new Text($"Общее количество позиций: {report.PositionCount}"));
                    totalRun.RunProperties = new RunProperties(new Bold());
                    totalP.Append(totalRun);
                    body.AppendChild(totalP);

                    Paragraph sumP = new Paragraph();
                    Run sumRun = new Run(new Text($"Итоговая сумма: {report.TotalAmount:N2} руб."));
                    sumRun.RunProperties = new RunProperties(new Bold());
                    sumP.Append(sumRun);
                    body.AppendChild(sumP);

                    // 6. Подпись
                    body.AppendChild(new Paragraph(new Run(new Text(" "))));
                    body.AppendChild(new Paragraph(new Run(new Text($"Дата формирования: {report.GeneratedDate:dd.MM.yyyy HH:mm}"))));
                    body.AppendChild(new Paragraph(new Run(new Text($"Ответственный: {report.ResponsibleEmployee ?? "—"}"))));

                    mainPart.Document.Save();
                }
                return string.Empty; // Успех
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

        private TableCell CreateCell(string text, bool isBold = false)
        {
            TableCell cell = new TableCell();
            Paragraph p = new Paragraph();
            Run r = new Run(new Text(text));
            if (isBold) r.RunProperties = new RunProperties(new Bold());
            p.Append(r);
            cell.Append(p);
            return cell;
        }
    }
}
