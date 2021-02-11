using System.ComponentModel.DataAnnotations;

namespace FoodPal.Providers.DomainModels
{
    public class ProviderCategory : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}