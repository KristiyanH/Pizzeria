namespace Pizzeria.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Pizzeria.Web.ViewModels.Products;

    public interface IProductsService
    {
        public Task CreateAsync(CreateProductViewModel model);

        public List<AllProductsViewModel> All();
    }
}
