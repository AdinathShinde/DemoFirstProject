using DemoFirstProject.Model.Domain;
using DemoFirstProject.Model.DTO;

namespace DemoFirstProject.Repository
{
    public interface IGET_DashCountRepository
    {
        Task<List<GET_DashCount>> getasync();
    }
}
