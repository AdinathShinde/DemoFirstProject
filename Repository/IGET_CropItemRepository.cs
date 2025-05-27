using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface IGET_CropItemRepository
    {
        Task<List<GET_CropItem>> getasync(GET_CropItemDomain input);
        Task<List<GET_CropItem>> Searchasync(GET_CropItemDomain input);
    }
}
