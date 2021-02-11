using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodPal.Providers.DomainModels
{
    public class CatalogueItem : BaseEntity
    {
        [MaxLength(150)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        [Required]
        public decimal Price { get; set; }

        public Catalogue Catalogue { get; set; }

        public CatalogueItemCategory Category { get; set; }
        public int CategoryId { get; set; }

        [NotMapped]
        public string ImageUrl { get; set; }
    }
}