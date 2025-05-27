using DemoFirstProject.Model.Domain;
using DemoFirstProject.Model.DTO;

namespace DemoFirstProject.Repository
{
    public interface ISP_AddUpdCropItemRepository
    {
        Task<List<ApiRespones>>getasync(SP_AddUpdCropItem input);
    }
}
