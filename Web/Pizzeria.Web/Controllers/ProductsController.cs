namespace Pizzeria.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Pizzeria.Data.Common.Repositories;
    using Pizzeria.Data.Models;
    using Pizzeria.Services.Data;
    using Pizzeria.Web.ViewModels.Products;
    using System.Threading.Tasks;

    public class ProductsController : BaseController
    {
        private readonly IProductsService productService;

        public ProductsController(IProductsService productService)
        {
            this.productService = productService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.productService.CreateAsync(model);

            return this.RedirectToAction("Index", "Home");
        }
    }
}
