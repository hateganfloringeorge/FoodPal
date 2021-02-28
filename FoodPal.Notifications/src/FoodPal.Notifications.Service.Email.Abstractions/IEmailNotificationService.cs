using FoodPal.Notifications.Dto.Intern;
using System;
using System.Threading.Tasks;

namespace FoodPal.Notifications.Service.Email
{
    public interface IEmailNotificationService
    {
        Task<bool> Send(NotificationServiceDto notificationServiceDto);
    }
}