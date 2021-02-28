using FoodPal.Notifications.Common.Enums;
using System;

namespace FoodPal.Notifications.Domain
{
    public class Notification : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string CreateBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset CreateAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
        public NotificationTypeEnum Type { get; set; }
        public NotificationStatusEnum Status { get; set; }
        public string Info { get; set; }
    }
}