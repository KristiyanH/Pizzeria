namespace Pizzeria.Services.Data
{
    using Pizzeria.Web.ViewModels.Products;
    using System.Collections.Generic;
    using System.Threading.Tasks;

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
