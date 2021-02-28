using FoodPal.Notifications.Service;
using FoodPal.Notifications.Service.Email;
using FoodPal.Notifications.Common.Enums;
using FoodPal.Notifications.Dto.Intern;
using System;
using System.Threading.Tasks;

namespace FoodPal.Notifications.Service
{
    public class NotificationService : INotificationService
    {
        private readonly IEmailNotificationService _emailNotificationService;

        public NotificationService(IEmailNotificationService emailNotificationService)
        {
            this._emailNotificationService = emailNotificationService;
        }

        public async Task<bool> Send(NotificationTypeEnum notificationTypeEnum, NotificationServiceDto notificationServiceDto)
        {
            switch (notificationTypeEnum)
            {
                case NotificationTypeEnum.Email:
                    return await this._emailNotificationService.Send(notificationServiceDto);
                case NotificationTypeEnum.Text:
                    throw new NotImplementedException("Text type not implemented");
                default:
                    return true;
            }
        }
    }
}