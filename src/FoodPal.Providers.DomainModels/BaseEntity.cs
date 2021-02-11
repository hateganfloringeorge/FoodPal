using System;

namespace FoodPal.Providers.DomainModels
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}