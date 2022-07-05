namespace Pizzeria.Data.Models
{
    using Pizzeria.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {
        public string Name { get; init; }

        public string ImageUrl { get; init; }

        public string Description { get; init; }

        public int Weight { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int? SizeId { get; set; }

        public Size Size { get; set; }
    }
}
