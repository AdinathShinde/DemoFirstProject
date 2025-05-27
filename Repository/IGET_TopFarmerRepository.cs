using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface IGET_TopFarmerRepository
    {
        Task<List<GET_TopFarmer>> getasync(GET_TopFarmerDomain input);
    }
}
