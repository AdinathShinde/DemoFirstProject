using DemoFirstProject.Model.Domain;

namespace DemoFirstProject.Repository
{
    public interface INotificationRepository
    {
        Task SendNotificationAsync(Notification notification);
    }
}
