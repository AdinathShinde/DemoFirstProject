using DemoFirstProject.Model.Domain;
using DemoFirstProject.Model.DTO;
using DemoFirstProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoFirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentUploadController : ControllerBase
    {
        private readonly IDocumentUploadRepository _repository;

        public DocumentUploadController(IDocumentUploadRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] DocumentUploadDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dto.Files.Count != dto.FileNames.Count)
                return BadRequest("Mismatch between file count and names.");

            var validation = ValidateFileUpload(dto);
            if (!validation.Item1)
                return BadRequest(validation.Item2);

            var documents = new List<DocumentUpload>();

            for (int i = 0; i < dto.Files.Count; i++)
            {
                documents.Add(new DocumentUpload
                {
                    File = dto.Files[i],
                    FileName = Path.GetFileNameWithoutExtension(dto.FileNames[i]),
                    FileSizeInBytes = dto.Files[i].Length,
                    FileDescription = dto.FileDescription,
                });
            }

            var uploadedDocs = await _repository.UploadAsync(documents);

            return Ok(uploadedDocs.Select(doc => new
            {
                doc.FileName,
                doc.FileSizeInBytes,
                doc.FilePath
            }));
        }

        private Tuple<bool, string> ValidateFileUpload(DocumentUploadDto dto)
        {
            var allowedExtensions = new[] { ".pdf" };

            foreach (var file in dto.Files)
            {
                string ext = Path.GetExtension(file.FileName).ToLower();

                if (!allowedExtensions.Contains(ext))
                    return Tuple.Create(false, $"Only PDFs are allowed. Got: {ext}");

                if (file.Length > 20 * 1024 * 1024)
                    return Tuple.Create(false, "File size exceeds 20MB.");
            }

            return Tuple.Create(true, "Valid");
        }
    }
}
