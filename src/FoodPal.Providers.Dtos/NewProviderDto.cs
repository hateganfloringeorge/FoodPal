using System;
using System.ComponentModel.DataAnnotations;

namespace FoodPal.Providers.Dtos
{
    public class NewProviderDto
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
        public NewCatalogueDto Catalogue { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "The field {0} must be greater than 0.")]
        public int CustomerId { get; set; }
    }
}