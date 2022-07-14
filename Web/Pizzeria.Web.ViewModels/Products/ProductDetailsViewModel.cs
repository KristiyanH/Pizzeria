namespace Pizzeria.Web.ViewModels.Products
{
    using System.ComponentModel.DataAnnotations;

    public class ProductDetailsViewModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        public string Description { get; init; }

        public int Weight { get; init; }

        public decimal Price { get; init; }

        public int? SizeId { get; set; }

        public string SizeName { get; set; }
    }
}
