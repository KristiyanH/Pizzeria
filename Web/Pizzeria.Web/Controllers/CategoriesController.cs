namespace Pizzeria.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Pizzeria.Services.Data.Categories;
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
            try
            {
                this.categoriesService.Remove(id);
                return this.RedirectToAction("Index", "Home");
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
                return this.View(this.categoriesService.EditGet(id));
            }
            catch (ArgumentNullException)
            {
                return this.RedirectToAction("Home", "Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel model)
        {
            try
            {
                await this.categoriesService.EditPost(model);
                return this.RedirectToAction("Index", "Home");
            }
            catch (ArgumentNullException)
            {
                return this.RedirectToAction("Home", "Error");
            }
        }
    }
}
