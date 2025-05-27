using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface IGET_MainGroupRepository
    {
        Task<List<GET_MainGroup>> getasync();
    }
}
