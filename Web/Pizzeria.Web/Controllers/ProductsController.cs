namespace Pizzeria.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Pizzeria.Services.Data.Products;
    using Pizzeria.Web.ViewModels.Products;

    public class ProductsController : BaseController
    {
        private readonly IProductsService productService;

        public ProductsController(IProductsService productService)
        {
            this.productService = productService;
        }

        public IActionResult Create()
        {
            return this.View(new CreateProductViewModel
            {
                Categories = this.productService.GetProductCategories(),
                Sizes = this.productService.GetProductSizes(),
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Categories = this.productService.GetProductCategories();
                model.Sizes = this.productService.GetProductSizes();
                return this.View(model);
            }

            await this.productService.CreateAsync(model);

            return this.RedirectToAction("All");
        }

        public IActionResult All([FromQuery] AllProductsQueryModel query)
        {
            try
            {
                var productsQuery = this.productService.All().AsQueryable();

                if (!string.IsNullOrWhiteSpace(query.Category))
                {
                    productsQuery = productsQuery.Where(x => x.Category.Name == query.Category);
                }

                if (!string.IsNullOrWhiteSpace(query.Size))
                {
                    productsQuery = productsQuery.Where(x => x.Size.Name == query.Size);
                }

                if (!string.IsNullOrWhiteSpace(query.SearchTerm))
                {
                    productsQuery = productsQuery.Where(x => x.Name.ToLower().Contains(query.SearchTerm.ToLower()) ||
                    x.Description.ToLower().Contains(query.SearchTerm.ToLower()));
                }

                productsQuery = query.Sorting switch
                {
                    ProductSorting.Alphabetical => productsQuery.OrderBy(x => x.Name),
                    ProductSorting.PriceAscending => productsQuery.OrderBy(x => x.Price),
                    ProductSorting.PriceDescending => productsQuery.OrderByDescending(x => x.Price),
                    _ => productsQuery.OrderBy(x => x),
                };

                var products = productsQuery
                    .Skip((query.CurrentPage - 1) * AllProductsQueryModel.ProductsPerPage)
                    .Take(AllProductsQueryModel.ProductsPerPage)
                    .ToList();

                return this.View(new AllProductsQueryModel
                {
                    Products = products,
                    SearchTerm = query.SearchTerm,
                    Categories = this.productService.GetProductCategories(),
                    Category = query.Category,
                    Sizes = this.productService.GetProductSizes(),
                    TotalProducts = productsQuery.Count(),
                    CurrentPage = query.CurrentPage,
                });
            }
            catch (ArgumentNullException)
            {
                return this.RedirectToAction("Home", "Error");
            }
        }

        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await this.productService.Remove(id);

                return this.RedirectToAction("All");
            }
            catch (ArgumentNullException)
            {
                return this.RedirectToAction("Home", "Error");
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                var model = this.productService.EditProductGet(id);
                model.Sizes = this.productService.GetProductSizes();
                return this.View(model);
            }
            catch (ArgumentNullException)
            {
                return this.RedirectToAction("Home", "Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(model);
                }

                await this.productService.EditProductPost(model);

                return this.RedirectToAction("All");
            }
            catch (ArgumentNullException)
            {
                return this.RedirectToAction("Home", "Error");
            }
        }

        public IActionResult Details(int id)
        {
            return this.View(this.productService.GetProduct(id));
        }
    }
}
