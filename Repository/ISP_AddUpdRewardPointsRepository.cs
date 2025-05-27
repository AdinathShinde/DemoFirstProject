using DemoFirstProject.Model.Domain;
using DemoFirstProject.Model.DTO;

namespace DemoFirstProject.Repository
{
    public interface ISP_AddUpdRewardPointsRepository
    {
        Task<List<ApiRespones>> getasync(SP_AddUpdRewardPoints input);
    }
}
