using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface IGET_RewardPointRepository
    {
        Task<List<GET_RewardPoint>> getasync(GET_RewardPointdtoDomain input);
    }
}
