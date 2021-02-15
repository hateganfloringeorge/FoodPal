using System.ComponentModel.DataAnnotations;

namespace FoodPal.Providers.Dtos
{
    public class NewCatalogueItemDto
    {
        [MaxLength(150)]
        [Required]
        public string Name { get; set; }

        [RegularExpression(@"^\d{1,3}(\.\d{1,2})?$", ErrorMessage = "Wrong value for category item price")]
        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CatalogueId { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}