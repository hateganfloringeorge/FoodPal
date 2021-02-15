using System.ComponentModel.DataAnnotations;

namespace FoodPal.Providers.Dtos
{
    public class NewCatalogueDto
    {
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
    }
}