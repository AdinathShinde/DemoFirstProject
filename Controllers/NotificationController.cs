using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DemoFirstProject.Model.Domain;
using DemoFirstProject.Model.DTO;
using DemoFirstProject.Repository;

namespace YourApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository _repository;

        public NotificationController(INotificationRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> SendNotification([FromBody] Notificationdto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Message) || string.IsNullOrWhiteSpace(dto.Receiver))
                return BadRequest("Message and Receiver are required.");

            var notification = new Notification
            {
                Message = dto.Message,
                Receiver = dto.Receiver
            };

            await _repository.SendNotificationAsync(notification);

            return Ok(new { success = true, message = dto.Message });
        }
    }
}
