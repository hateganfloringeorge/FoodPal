using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodPal.Providers.Dtos
{
    public class CatalogueDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public List<CatalogueItemDto> Items { get; set; }

    }
}