using DemoFirstProject.Model.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoFirstProject.Repository
{
    public class SqlNotificationRepository : INotificationRepository
    {
        private static List<Notification> notifications = new();

        public async Task SendNotificationAsync(Notification notification)
        {
            notification.Id = notifications.Count + 1;
            notification.SentAt = DateTime.UtcNow;

            notifications.Add(notification);
            await Task.CompletedTask; // simulate async
        }
    }
}
