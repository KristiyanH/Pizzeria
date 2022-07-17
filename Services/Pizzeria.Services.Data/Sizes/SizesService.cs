namespace Pizzeria.Services.Data.Sizes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Pizzeria.Data.Common.Repositories;
    using Pizzeria.Data.Models;
    using Pizzeria.Web.ViewModels.Sizes;

    public class SizesService : ISizesService
    {
        private readonly IDeletableEntityRepository<Size> sizesRepository;
        private readonly IMapper mapper;

        public SizesService(IDeletableEntityRepository<Size> sizesRepository, IMapper mapper)
        {
            this.sizesRepository = sizesRepository;
            this.mapper = mapper;
        }

        public List<SizeViewModel> All()
        {
            var sizes =
               this.sizesRepository
               .All()
               .ToList();

            return this.mapper.Map<List<SizeViewModel>>(sizes);
        }

        public async Task CreateAsync(SizeViewModel model)
        {
            var size = this.mapper.Map<Size>(model);
            await this.sizesRepository.AddAsync(size);
            await this.sizesRepository.SaveChangesAsync();
        }

        public SizeViewModel EditGet(int id)
        {
            var size =
               this.sizesRepository
               .All()
               .FirstOrDefault(x => x.Id == id);

            if (size == null)
            {
                throw new ArgumentNullException($"Size with id: {id} does not exist.");
            }

            var sizeModel = this.mapper.Map<SizeViewModel>(size);

            return sizeModel;
        }

        public async Task EditPost(SizeViewModel model)
        {
            var size =
               this.sizesRepository
               .All()
               .FirstOrDefault(x => x.Id == model.Id);

            if (size == null)
            {
                throw new ArgumentNullException($"Size with id: {model.Id} does not exist.");
            }

            if (model.Name != size.Name)
            {
                size.Name = model.Name;
            }

            this.sizesRepository.Update(size);
            await this.sizesRepository.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var size =
               this.sizesRepository
               .All()
               .FirstOrDefault(x => x.Id == id);

            if (size == null)
            {
                throw new ArgumentNullException($"Size with id: {id} does not exist.");
            }

            this.sizesRepository.Delete(size);
            await this.sizesRepository.SaveChangesAsync();
        }
    }
}
