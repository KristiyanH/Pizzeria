namespace Pizzeria.Web.ViewModels.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Pizzeria.Data.Models;

    public class CreateProductViewModel
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        [Required]
        public string Description { get; init; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<ProductCategoryViewModel> Categories { get; set; }

        [Display(Name = "Size")]
        public int? SizeId { get; set; }

        public IEnumerable<ProductSizeViewModel> Sizes { get; set; }
    }
}
