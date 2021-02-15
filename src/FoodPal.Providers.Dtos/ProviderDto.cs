using System;
using System.ComponentModel.DataAnnotations;

namespace FoodPal.Providers.Dtos
{
    public class ProviderDto
    {
        public int Id { get; set; }

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
        public CatalogueDto Catalogue { get; set; }

        public ProviderCategoryDto Category { get; set; }

        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "The field {0} must be greater than 0.")]
        public int CustomerId { get; set; }
    }
}