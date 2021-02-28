using FoodPal.Notifications.Service.Email;
using FoodPal.Notifications.Dto.Intern;
using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Options;
using FoodPal.Notifications.Common.Settings;

namespace FoodPal.Notifications.Service.Email
{
    public class EmailNotificationService : IEmailNotificationService
    {
        private readonly NotificationServiceSettings _notificationService;

        public EmailNotificationService(IOptions<NotificationServiceSettings> options)
        {
            this._notificationService = options.Value;
        }

        public async Task<bool> Send(NotificationServiceDto notificationServiceDto)
        {
            var client = new SendGridClient(this._notificationService.ApiKey);
            var sendGridMessage = MailHelper.CreateSingleEmail(
                        new EmailAddress(this._notificationService.From),
                        new EmailAddress(notificationServiceDto.Email),
                        notificationServiceDto.Subject,
                        "",
                        notificationServiceDto.Body
                    );
            var response = await client.SendEmailAsync(sendGridMessage);

            return response.IsSuccessStatusCode;
        }
    }
}