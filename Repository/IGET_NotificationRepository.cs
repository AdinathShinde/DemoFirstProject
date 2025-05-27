using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface IGET_NotificationRepository
    {
        Task<List<GET_Notification>>getasync (GET_NotificationDomain input);

    }
}
