namespace Pizzeria.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Pizzeria.Web.ViewModels.Products;

    public interface IProductsService
    {
        public Task CreateAsync(CreateProductViewModel model);

        public List<AllProductsViewModel> All();

        public Task Remove(int id);

        public IEnumerable<ProductCategoryViewModel> GetProductCategories();

        public IEnumerable<ProductSizeViewModel> GetProductSizes();

        public EditProductViewModel EditProductGet(int id);

        public Task EditProductPost(EditProductViewModel model);

        public ProductDetailsViewModel GetProduct(int id);
    }
}
