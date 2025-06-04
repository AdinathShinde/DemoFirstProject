using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface IGET_ShopAlotRepository
    { 
        Task<List<GET_ShopAlot>> getasync(GET_ShopAlotDomain input);
        Task<List<GET_ShopAlot>> Searchasync (GET_ShopAlotDomain input);

    }
}
