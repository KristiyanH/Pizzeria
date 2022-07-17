namespace Pizzeria.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Pizzeria.Services.Data;
    using Pizzeria.Web.ViewModels.Categories;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult All()
        {
            return this.View(this.categoriesService.All());
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.categoriesService.CreateAsync(model);
            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult Remove(int id)
        {
            this.categoriesService.Remove(id);
            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            return this.View(this.categoriesService.EditGet(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel model)
        {
            await this.categoriesService.EditPost(model);
            return this.RedirectToAction("Index", "Home");
        }
    }
}
