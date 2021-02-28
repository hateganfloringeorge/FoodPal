using FoodPal.Notifications.Common.Enums;
using System;
namespace FoodPal.Contracts
{
    public interface INewNotificationAdded
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public string CreateBy { get; set; }
        public string ModifiedBy { get; set; }
        public NotificationTypeEnum Type { get; set; }
        public NotificationStatusEnum Status { get; set; }
        public string Info { get; set; }
    }
}