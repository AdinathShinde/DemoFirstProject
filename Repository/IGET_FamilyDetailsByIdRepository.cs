using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface IGET_FamilyDetailsByIdRepository
    {
        Task<List<GET_FamilyDetailsById>> getasync(GET_FamilyDetailsByIdDomain input);
        Task<List<GET_FamilyDetailsById>> Searchasync(GET_FamilyDetailsByIdDomain input);
    }
}
