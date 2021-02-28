using System;
using System.Collections.Generic;

namespace FoodPal.Notifications.Domain
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}