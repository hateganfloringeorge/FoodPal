using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodPal.Providers.DomainModels
{
    public class Catalogue : BaseEntity
    {
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public List<CatalogueItem> Items { get; set; }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
    }
}