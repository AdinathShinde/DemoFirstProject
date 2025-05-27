namespace DemoFirstProject.Model.DTO
{
    public class ExcelExportRequestDto
    {
        public string FunctionName { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public List<string> SelectedColumns { get; set; }
    }
}
