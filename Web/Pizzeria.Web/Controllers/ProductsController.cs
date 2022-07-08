namespace Pizzeria.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Pizzeria.Data;
    using Pizzeria.Services.Data;
    using Pizzeria.Web.ViewModels.Products;

    public class ProductsController : BaseController
    {
        private readonly IProductsService productService;
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public ProductsController(IProductsService productService, ApplicationDbContext data, IMapper mapper)
        {
            this.productService = productService;
            this.data = data;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View(new CreateProductViewModel
            {
                Categories = this.GetProductCategories(),
                Sizes = this.GetProductSizes(),
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.productService.CreateAsync(model);

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var products = this.productService.All();
            return this.View(products);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await this.productService.Remove(id);

            return this.RedirectToAction("All");
        }

        private IEnumerable<ProductCategoryViewModel> GetProductCategories()
        {
            var categories = this.data.Categories.ToList();
            return this.mapper.Map<IEnumerable<ProductCategoryViewModel>>(categories);
        }

        private IEnumerable<ProductSizeViewModel> GetProductSizes()
        {
            var sizes = this.data.Sizes.ToList();
            return this.mapper.Map<IEnumerable<ProductSizeViewModel>>(sizes);
        }
    }
}
