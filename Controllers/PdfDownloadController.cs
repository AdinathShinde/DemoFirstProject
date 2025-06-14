using DemoFirstProject.Model.Domain;
using DemoFirstProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoFirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfDownloadController : ControllerBase
    {
        private readonly SqlFunctionExecutor _executor;
        private readonly PdfExporter _pdfExporter;

        public PdfDownloadController(SqlFunctionExecutor executor, PdfExporter pdfExporter)
        {
            _executor = executor;
            _pdfExporter = pdfExporter;
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

                var pdfBytes = _pdfExporter.ExportToPdf(dt, selectedCols);

                return File(pdfBytes, "application/pdf", $"{request.FunctionName}_Export.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
