using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface IGET_BankNameRepository
    {
        Task<List<GET_BankName>> getasync(GET_BankNameDomain input);
    }
}
