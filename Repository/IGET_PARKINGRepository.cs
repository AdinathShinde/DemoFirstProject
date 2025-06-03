using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface IGET_PARKINGRepository
    {
        Task<List<GET_PARKING>> getasync(GET_PARKINGDomain input);
        Task<List<GET_PARKING>> Searchasync(GET_PARKINGDomain input);
    }
}
