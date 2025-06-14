using DemoFirstProject.Model;
using DemoFirstProject.Model.Domain;
using DemoFirstProject.Model.DTO;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ExcelDownloadController : ControllerBase
{
    private readonly SqlFunctionExecutor _executor;
    private readonly ExcelExporter _excel;

    public ExcelDownloadController(SqlFunctionExecutor executor, ExcelExporter excel)
    {
        _executor = executor;
        _excel = excel;
    }

    [HttpPost("download")]
    public async Task<IActionResult> Download([FromBody] ExcelExportRequest request)
    {
        try
        {
            var dt = await _executor.ExecuteFunctionAsync(request.FunctionName, request.Parameters);

            // Filter only selected columns
            var selectedCols = request.ColumnsToInclude
                                .Where(c => dt.Columns.Contains(c))
                                .ToList();

            var bytes = _excel.ExportToExcel(dt, selectedCols);

            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{request.FunctionName}_Export.xlsx");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}