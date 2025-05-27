using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface IGET_MarketStoreRepository
    {
        Task<List<GET_MarketStore>> getasync(GET_MarketStoreDomain input);
        Task<List<GET_MarketStore>> Searchasync(GET_MarketStoreDomain input);
    }
}
