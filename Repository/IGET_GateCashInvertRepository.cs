using DemoFirstProject.Model.Domain;
using DemoFirstProject.Model.DTO;

namespace DemoFirstProject.Repository
{
    public interface IGET_GateCashInvertRepository
    {
        Task<List<GET_GateCashInvert>> getasync(GET_GateCashInvertDomain input);
        Task<List<GET_GateCashInvert>> Searchasync(GET_GateCashInvertDomain input);
    }
}
