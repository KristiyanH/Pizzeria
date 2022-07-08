﻿namespace Pizzeria.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Pizzeria.Data.Common.Repositories;
    using Pizzeria.Data.Models;
    using Pizzeria.Web.ViewModels.Products;

    public class ProductsService : IProductsService
    {
        private readonly IDeletableEntityRepository<Product> productsRepository;
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<Size> sizesRepository;
        private readonly IMapper mapper;

        public ProductsService(
            IDeletableEntityRepository<Product> productsRepository,
            IMapper mapper,
            IDeletableEntityRepository<Size> sizesRepository,
            IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.productsRepository = productsRepository;
            this.mapper = mapper;
            this.sizesRepository = sizesRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public List<AllProductsViewModel> All()
        {
            var products = this.mapper.Map<List<AllProductsViewModel>>(this.productsRepository.All().ToList());

            return products;
        }

        public async Task CreateAsync(CreateProductViewModel model)
        {
            var product = this.mapper.Map<Product>(model);
            await this.productsRepository.AddAsync(product);
            await this.productsRepository.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var product = this.productsRepository.All().FirstOrDefault(x => x.Id == id);
            this.productsRepository.Delete(product);
            await this.productsRepository.SaveChangesAsync();
        }

        public IEnumerable<ProductCategoryViewModel> GetProductCategories()
        {
            var categories = this.categoriesRepository.All().ToList();
            return this.mapper.Map<IEnumerable<ProductCategoryViewModel>>(categories);
        }

        public IEnumerable<ProductSizeViewModel> GetProductSizes()
        {
            var sizes = this.sizesRepository.All().ToList();
            return this.mapper.Map<IEnumerable<ProductSizeViewModel>>(sizes);
        }
    }
}
