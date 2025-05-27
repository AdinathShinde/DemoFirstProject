using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface ISP_DeletFamilyRepository
    {
        Task<List<ApiRespones>> getasync(SP_DeletFamily input);
    }
}
