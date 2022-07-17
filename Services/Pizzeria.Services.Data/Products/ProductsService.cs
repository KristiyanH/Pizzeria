namespace Pizzeria.Services.Data.Products
{
    using System;
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
            var products =
                mapper
                .Map<List<AllProductsViewModel>>(productsRepository.All().ToList());

            foreach (var product in products)
            {
                product.Category =
                    categoriesRepository
                    .All()
                    .FirstOrDefault(x => x.Id == product.CategoryId);

                if (product.Category == null)
                {
                    throw new ArgumentNullException($"Invalid Category for product with id: ${product.Id}");
                }

                product.Size =
                    sizesRepository
                    .All()
                    .FirstOrDefault(x => x.Id == product.SizeId);
            }

            return products;
        }

        public async Task CreateAsync(CreateProductViewModel model)
        {
            var product = mapper.Map<Product>(model);
            await productsRepository.AddAsync(product);
            await productsRepository.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var product =
                productsRepository
                .All()
                .FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new ArgumentNullException($"Product with id: {id} does not exist.");
            }

            productsRepository.Delete(product);
            await productsRepository.SaveChangesAsync();
        }

        public IEnumerable<ProductCategoryViewModel> GetProductCategories()
        {
            var categories =
                categoriesRepository
                .All()
                .ToList();

            return mapper.Map<IEnumerable<ProductCategoryViewModel>>(categories);
        }

        public IEnumerable<ProductSizeViewModel> GetProductSizes()
        {
            var sizes =
                sizesRepository
                .All()
                .ToList();

            return mapper.Map<IEnumerable<ProductSizeViewModel>>(sizes);
        }

        public EditProductViewModel EditProductGet(int id)
        {
            var product =
                productsRepository
                .All()
                .FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new ArgumentNullException($"Product with id: {id} does not exist.");
            }

            var editModel = mapper.Map<EditProductViewModel>(product);

            return editModel;
        }

        public async Task EditProductPost(EditProductViewModel model)
        {
            var product =
                productsRepository
                .All()
                .FirstOrDefault(x => x.Id == model.Id);

            if (product == null)
            {
                throw new ArgumentNullException($"Product with id: {model.Id} does not exist.");
            }

            product.Name = model.Name;
            product.ImageUrl = model.ImageUrl;
            product.Description = model.Description;
            product.Price = model.Price;
            product.SizeId = model.SizeId;

            productsRepository.Update(product);
            await productsRepository.SaveChangesAsync();
        }

        public ProductDetailsViewModel GetProduct(int id)
        {
            var product =
                productsRepository
                .All()
                .FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new ArgumentNullException($"Product with id: {id} does not exist.");
            }

            var detailsModel = mapper.Map<ProductDetailsViewModel>(product);

            var sizeName =
                sizesRepository
                .All()
                .FirstOrDefault(x => x.Id == detailsModel.SizeId).Name;

            if (sizeName != null)
            {
                detailsModel.SizeName = sizeName;
            }

            return detailsModel;
        }
    }
}
