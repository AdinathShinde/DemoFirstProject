using DemoFirstProject.Model.Domain;
using DemoFirstProject.Model.DTO;

namespace DemoFirstProject.Repository
{
    public interface ISP_DeleteRewardRepository
    {
        Task<List<ApiRespones>> getasync(SP_DeleteReward input);
    }
}
