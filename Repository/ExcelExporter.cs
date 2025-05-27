using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;
using System.Drawing;

public class ExcelExporter
{
    public byte[] ExportToExcel(DataTable dt, List<string> selectedColumns)
    {
        using var package = new ExcelPackage();
        var ws = package.Workbook.Worksheets.Add("Data");

        int colIndex = 1;
        var columnIndices = new Dictionary<string, int>();

        // Header with highlight
        foreach (var colName in selectedColumns)
        {
            ws.Cells[1, colIndex].Value = colName;
            ws.Cells[1, colIndex].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[1, colIndex].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
            columnIndices[colName] = colIndex;
            colIndex++;
        }

        int rowIndex = 2;

        foreach (DataRow row in dt.Rows)
        {
            foreach (var colName in selectedColumns)
            {
                if (dt.Columns.Contains(colName))
                {
                    ws.Cells[rowIndex, columnIndices[colName]].Value = row[colName];
                }
            }
            rowIndex++;
        }

        ws.Cells.AutoFitColumns();
        return package.GetAsByteArray();
    }
}
