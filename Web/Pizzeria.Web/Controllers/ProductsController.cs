namespace Pizzeria.Web.Controllers
{
    using System;
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
    }
}
