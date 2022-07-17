namespace Pizzeria.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Pizzeria.Services.Data.Sizes;
    using Pizzeria.Web.ViewModels.Sizes;

    public class SizesController : BaseController
    {
        private readonly ISizesService sizesService;

        public SizesController(ISizesService sizesService)
        {
            this.sizesService = sizesService;
        }

        public IActionResult All()
        {
            return this.View(this.sizesService.All());
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SizeViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.sizesService.CreateAsync(model);
            return this.RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await this.sizesService.Remove(id);
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
                return this.View(this.sizesService.EditGet(id));
            }
            catch (ArgumentNullException)
            {
                return this.RedirectToAction("Home", "Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SizeViewModel model)
        {
            try
            {
                await this.sizesService.EditPost(model);
                return this.RedirectToAction("Index", "Home");
            }
            catch (ArgumentNullException)
            {
                return this.RedirectToAction("Home", "Error");
            }
        }
    }
}
