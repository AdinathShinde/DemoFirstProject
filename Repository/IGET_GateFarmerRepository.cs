using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface IGET_GateFarmerRepository
    {
        Task<List<GET_GateFarmer>> getasync(GET_GateFarmerDomain input);
        Task<List<GET_GateFarmer>> Searchasync(GET_GateFarmerDomain input);
    }
}
