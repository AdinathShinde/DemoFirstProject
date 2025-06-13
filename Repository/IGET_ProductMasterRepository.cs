using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface IGET_ProductMasterRepository
    {
        Task<List<GET_ProductMaster>> getasync(GET_ProductMasterDomain input);
        Task<List<GET_ProductMaster>> Searchasync(GET_ProductMasterDomain input);
    }
}
