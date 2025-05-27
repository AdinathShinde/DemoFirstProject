using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface ISP_DeleteCaretRepository
    {
        Task<List<ApiRespones>> getasync(SP_DeleteCaret input);
    }
}
