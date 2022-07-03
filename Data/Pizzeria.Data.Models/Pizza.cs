namespace Pizzeria.Data.Models
{
    using Pizzeria.Data.Common.Models;

    public class Pizza : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Size { get; set; }

        public int Weight { get; set; }

        public decimal Price { get; set; }

        public string Ingredients { get; set; }
    }
}
