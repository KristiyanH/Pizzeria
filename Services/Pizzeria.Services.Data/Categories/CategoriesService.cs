namespace Pizzeria.Services.Data.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Pizzeria.Data.Common.Repositories;
    using Pizzeria.Data.Models;
    using Pizzeria.Web.ViewModels.Categories;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IMapper mapper;

        public CategoriesService(
            IDeletableEntityRepository<Category> categoriesRepository,
            IMapper mapper)
        {
            this.categoriesRepository = categoriesRepository;
            this.mapper = mapper;
        }

        public List<CategoryViewModel> All()
        {
            var categories =
                this.categoriesRepository
                .All()
                .ToList();

            return this.mapper.Map<List<CategoryViewModel>>(categories);
        }

        public async Task CreateAsync(CategoryViewModel model)
        {
            var category = this.mapper.Map<Category>(model);
            await this.categoriesRepository.AddAsync(category);
            await this.categoriesRepository.SaveChangesAsync();
        }

        public CategoryViewModel EditGet(int id)
        {
            var category =
                this.categoriesRepository
                .All()
                .FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                throw new ArgumentNullException($"Category with id: {id} does not exist.");
            }

            var categoryModel = this.mapper.Map<CategoryViewModel>(category);

            return categoryModel;
        }

        public async Task EditPost(CategoryViewModel model)
        {
            var category =
               this.categoriesRepository
               .All()
               .FirstOrDefault(x => x.Id == model.Id);

            if (category == null)
            {
                throw new ArgumentNullException($"Category with id: {model.Id} does not exist.");
            }

            if (model.Name != category.Name)
            {
                category.Name = model.Name;
            }

            this.categoriesRepository.Update(category);
            await this.categoriesRepository.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var category =
                this.categoriesRepository
                .All()
                .FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                throw new ArgumentNullException($"Category with id: {id} does not exist.");
            }

            this.categoriesRepository.Delete(category);
            await this.categoriesRepository.SaveChangesAsync();
        }
    }
}
