namespace Pizzeria.Web.ViewModels.Products
{
    using System.ComponentModel.DataAnnotations;

    using Pizzeria.Data.Models;

    public class AllProductsViewModel
    {
        public int Id { get; set; }

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

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int SizeId { get; set; }

        public Size Size { get; set; }
    }
}
