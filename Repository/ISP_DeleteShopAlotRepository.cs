using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface ISP_DeleteShopAlotRepository
    {
        Task<List<ApiRespones>> getasync(SP_DeleteShopAlot input);
    }
}
