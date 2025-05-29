using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface IGET_BillNoSearchRepository
    {
        Task<List<GET_BillNoSearch>> getasync(GET_BillNoSearchDomain input);
        Task<List<GET_BillNoSearch>> Searchasync(GET_BillNoSearchDomain input);
    }
}
