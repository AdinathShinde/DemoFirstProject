using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


namespace DemoFirstProject.Model.DTO
{
    public class DocumentUploadDto
    {
   
        [Required]
        public List<IFormFile> Files { get; set; }

        [Required]
        public List<string> FileNames { get; set; }

        public string? FileDescription { get; set; }
    }
}
