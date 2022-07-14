namespace Pizzeria.Web.ViewModels.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class EditProductViewModel
    {
        public int Id { get; init; }

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

        [Display(Name = "Size")]
        public int? SizeId { get; set; }

        public IEnumerable<ProductSizeViewModel> Sizes { get; set; }
    }
}
