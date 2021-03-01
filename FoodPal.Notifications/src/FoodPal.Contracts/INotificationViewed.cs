using FoodPal.Notifications.Common.Enums;

namespace FoodPal.Contracts
{
    public interface INotificationViewed
    {
        public int Id { get; set; }

        // should this be changed now?
        // public string ModifiedBy { get; set; }

        public NotificationStatusEnum Status { get; set; }
    }
}
