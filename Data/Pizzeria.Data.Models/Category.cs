namespace Pizzeria.Data.Models
{
    using Pizzeria.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
