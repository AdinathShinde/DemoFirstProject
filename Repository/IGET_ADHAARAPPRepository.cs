using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface IGET_ADHAARAPPRepository
    {
        Task<List<GET_ADHAARAPP>> getasync(GET_ADHAARAPPDomain input);
    }
}
