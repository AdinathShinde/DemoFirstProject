using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface IDocumentUploadRepository
    {
        Task<List<DocumentUpload>> UploadAsync(List<DocumentUpload> documents);
    }
}
