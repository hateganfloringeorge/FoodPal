using FoodPal.Deliveries.Common;
using System;

namespace FoodPal.Deliveries.Domain
{
    public class Delivery : IEntity
    {
        public int Id { get; set; }

        public DeliveryStatusEnum Status { get; set; }

        public int UserId { get; set; }

        public User User { get; set;}

        public int OrderId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public string ModifiedBy { get; set; }

        public string Info { get; set; }


    }
}
