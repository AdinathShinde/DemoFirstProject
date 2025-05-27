using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface IGET_VyapariLimitRepository
    {
        Task<List<GET_VyapariLimit>> getasync(GET_VyapariLimitDomain input);
    }
}
