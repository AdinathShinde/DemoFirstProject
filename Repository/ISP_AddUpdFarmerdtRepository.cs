using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface ISP_AddUpdFarmerdtRepository
    {
        Task<List<ApiRespones>> getasync(List<SP_AddUpdFarmer> input);
    }
}
