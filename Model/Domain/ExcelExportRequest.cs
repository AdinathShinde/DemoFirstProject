namespace DemoFirstProject.Model.Domain
{
    public class ExcelExportRequest
    {
        public string FunctionName { get; set; }
        public Dictionary<string, string> Parameters { get; set; }

        // Add this property for column filtering
        public List<string> ColumnsToInclude { get; set; } = new List<string>();
    }
}
