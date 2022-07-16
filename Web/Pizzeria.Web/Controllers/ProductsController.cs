namespace Pizzeria.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Pizzeria.Services.Data;
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

        public IActionResult All([FromQuery] AllProductsQueryModel model)
        {
            var productsQuery = this.productService.All().AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.Category))
            {
                productsQuery = productsQuery.Where(x => x.Category.Name == model.Category);
            }

            if (!string.IsNullOrWhiteSpace(model.Size))
            {
                productsQuery = productsQuery.Where(x => x.Size.Name == model.Size);
            }

            if (!string.IsNullOrWhiteSpace(model.SearchTerm))
            {
                productsQuery = productsQuery.Where(x => x.Name.ToLower().Contains(model.SearchTerm.ToLower()) ||
                x.Description.ToLower().Contains(model.SearchTerm.ToLower()));
            }

            productsQuery = model.Sorting switch
            {
                ProductSorting.Alphabetical => productsQuery.OrderBy(x => x.Name),
                ProductSorting.PriceAscending => productsQuery.OrderBy(x => x.Price),
                ProductSorting.PriceDescending => productsQuery.OrderByDescending(x => x.Price),
                _ => productsQuery.OrderBy(x => x),
            };

            return this.View(new AllProductsQueryModel
            {
                Products = productsQuery.ToList(),
                SearchTerm = model.SearchTerm,
                Categories = this.productService.GetProductCategories(),
                Sizes = this.productService.GetProductSizes(),
            });
        }

        public async Task<IActionResult> Remove(int id)
        {
            await this.productService.Remove(id);

            return this.RedirectToAction("All");
        }

        public IActionResult Edit(int id)
        {
            var model = this.productService.EditProductGet(id);
            model.Sizes = this.productService.GetProductSizes();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.productService.EditProductPost(model);

            return this.RedirectToAction("All");
        }

        public IActionResult Details(int id)
        {
            return this.View(this.productService.GetProduct(id));
        }
    }
}
