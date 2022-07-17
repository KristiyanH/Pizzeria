namespace Pizzeria.Services.Data.Sizes
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Pizzeria.Web.ViewModels.Sizes;

    public interface ISizesService
    {
        public Task CreateAsync(SizeViewModel model);

        public Task Remove(int id);

        public SizeViewModel EditGet(int id);

        public Task EditPost(SizeViewModel model);

        public List<SizeViewModel> All();
    }
}
