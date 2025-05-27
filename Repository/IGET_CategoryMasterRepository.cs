using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface IGET_CategoryMasterRepository
    {
        Task<List<GET_CategoryMaster>> getasync(GET_CategoryMasterDomain input);
    }
}
