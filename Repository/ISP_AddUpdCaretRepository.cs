using DemoFirstProject.Model.Domain;
using DemoFirstProject.Model.DTO;

namespace DemoFirstProject.Repository
{
    public interface ISP_AddUpdCaretRepository
    {
        Task<List<ApiRespones>>getasync(SP_AddUpdCaret input);
    }
}
