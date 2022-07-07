namespace Pizzeria.Web.ViewModels.Products
{
    using System.ComponentModel.DataAnnotations;

    public class AllProductsViewModel
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
    }
}
