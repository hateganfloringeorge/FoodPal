﻿using System.ComponentModel.DataAnnotations;

namespace FoodPal.Providers.Dtos
{
    public class CatalogueItemDto
    {
        public int Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string Name { get; set; }

        [RegularExpression(@"^\d{1,3}(\.\d{1,2})?$", ErrorMessage = "Wrong value for category item price")]
        [Required]
        public decimal Price { get; set; }

        public CatalogueItemCategoryDto Category { get; set; }
    }
}