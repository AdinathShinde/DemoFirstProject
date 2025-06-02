using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoFirstProject.Model.Domain
{
    public class DocumentUpload
    {
         
        [Key]
        public int Id { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

        public string FileName { get; set; } // Without extension

        public string? FileDescription { get; set; }

        public long FileSizeInBytes { get; set; }

        public string FilePath { get; set; } // Server path
    }
}

   
