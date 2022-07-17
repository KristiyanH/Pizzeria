namespace Pizzeria.Services.Data.Categories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Pizzeria.Web.ViewModels.Categories;

    public interface ICategoriesService
    {
        public Task CreateAsync(CategoryViewModel model);

        public Task Remove(int id);

        public CategoryViewModel EditGet(int id);

        public Task EditPost(CategoryViewModel model);

        public List<CategoryViewModel> All();
    }
}
