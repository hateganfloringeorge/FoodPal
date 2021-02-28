using FoodPal.Notifications.Common.Enums;
using FoodPal.Notifications.Dto.Intern;
using System;
using System.Threading.Tasks;

namespace FoodPal.Notifications.Service
{
    public interface INotificationService
    {
        Task<bool> Send(NotificationTypeEnum notificationTypeEnum, NotificationServiceDto notificationServiceDto);
    }
}