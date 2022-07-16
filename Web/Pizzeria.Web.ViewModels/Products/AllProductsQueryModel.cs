namespace Pizzeria.Web.ViewModels.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class AllProductsQueryModel
    {
        public const int ProductsPerPage = 3;

        public int CurrentPage { get; init; } = 1;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; }

        public string Category { get; init; }

        public int TotalProperties { get; set; }

        [Display(Name = "Search by Category")]
        public IEnumerable<ProductCategoryViewModel> Categories { get; init; }

        public string Size { get; init; }

        [Display(Name = "Search by Size")]
        public IEnumerable<ProductSizeViewModel> Sizes { get; init; }

        [Display(Name = "Sort by")]
        public ProductSorting Sorting { get; init; }

        public IEnumerable<AllProductsViewModel> Products { get; init; }
    }
}
