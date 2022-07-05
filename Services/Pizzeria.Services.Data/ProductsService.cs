namespace Pizzeria.Services.Data
{
    using System.Threading.Tasks;

    using AutoMapper;
    using Pizzeria.Data.Common.Repositories;
    using Pizzeria.Data.Models;
    using Pizzeria.Web.ViewModels.Products;

    public class ProductsService : IProductsService
    {
        private readonly IDeletableEntityRepository<Product> productsRepository;
        private readonly IMapper mapper;

        public ProductsService(IDeletableEntityRepository<Product> productsRepository, IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateProductViewModel model)
        {
            var product = this.mapper.Map<Product>(model);
            await this.productsRepository.AddAsync(product);
            await this.productsRepository.SaveChangesAsync();
        }
    }
}
