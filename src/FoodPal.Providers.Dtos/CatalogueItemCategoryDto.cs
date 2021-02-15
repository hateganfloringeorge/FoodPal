using System.ComponentModel.DataAnnotations;

namespace FoodPal.Providers.Dtos
{
    public class CatalogueItemCategoryDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}