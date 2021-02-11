using System.ComponentModel.DataAnnotations;

namespace FoodPal.Providers.DomainModels
{
    public class Provider : BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [MaxLength(300)]
        public string Location { get; set; }
        [Required]
        public Catalogue Catalogue { get; set; }

        public ProviderCategory Category { get; set; }

        public int CategoryId { get; set; }
        [Required]
        public int CustomerId { get; set; }

    }
}