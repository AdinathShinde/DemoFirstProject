using System.Data;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QDocument = QuestPDF.Fluent.Document;

namespace DemoFirstProject.Repository
{
    public class PdfExporter
    {
        public byte[] ExportToPdf(DataTable dt, List<string> selectedColumns)
        {
            var doc = QDocument.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    // Header
                    page.Header()
                        .Text("PDF Data Export")
                        .SemiBold()
                        .FontSize(16)
                        .FontColor(Colors.Blue.Medium);

                    // Content Table
                    page.Content()
                        .Table(table =>
                        {
                            // Define table columns based on selectedColumns
                            table.ColumnsDefinition(columns =>
                            {
                                foreach (var _ in selectedColumns)
                                    columns.RelativeColumn();
                            });

                            // Table Header
                            table.Header(header =>
                            {

                                foreach (var colName in selectedColumns)
                                {
                                    header.Cell()
                                        .Background(Colors.Blue.Medium)
                                        .Padding(5)
                                        .Text(colName)
                                        .FontColor(Colors.White)
                                        .Bold();
                                }
                            });
                            Console.WriteLine($"Rows: {dt.Rows.Count}");
                            // Table Rows (Data)
                            foreach (DataRow row in dt.Rows)
                            {
                                foreach (var colName in selectedColumns)
                                {
                                    string value = dt.Columns.Contains(colName)
                                        ? row[colName]?.ToString() ?? ""
                                        : "N/A";

                                    table.Cell()
                                        .BorderBottom(1)
                                        .BorderColor(Colors.Grey.Lighten2)
                                        .Padding(5)
                                        .Text(value)
                                        .FontColor(Colors.Black);
                                }
                            }
                        });

                    // Footer
                    page.Footer()
                        .AlignCenter()
                        .Text(txt =>
                        {
                            txt.Span("Page ");
                            txt.CurrentPageNumber();
                            txt.Span(" of ");
                            txt.TotalPages();
                        });
                });
            });

            return doc.GeneratePdf();
        }
    }
}
