using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Core.Resources;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CategotryService : ICategoriesService
    {

        private readonly IRepository<Category> categoriesRepo;
        private readonly IMapper mapper;

        public CategotryService(IRepository<Category> categoriesRepo, IMapper mapper)
        {
            this.categoriesRepo = categoriesRepo;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var result = await categoriesRepo.GetListBySpec(new Categories.GetAll());

            return mapper.Map<IEnumerable<CategoryDto>>(result);
        }

        public async Task<CategoryDto?> GetById(int id)
        {
            Category? item = await categoriesRepo.GetItemBySpec(new Categories.ById(id));

            if (item == null)
                throw new HttpException(ErrorMessages.CategoryNotFound, HttpStatusCode.NotFound);

            return mapper.Map<CategoryDto>(item);
        }

        public async Task Edit(CategoryDto category)
        {
            await categoriesRepo.Update(mapper.Map<Category>(category));
            await categoriesRepo.Save();
        }

        public async Task Create(CategoryDto category)
        {
            await categoriesRepo.Insert(mapper.Map<Category>(category));
            await categoriesRepo.Save();
        }

        public async Task Delete(int id)
        {
            if (await categoriesRepo.GetById(id) == null)
                throw new HttpException(ErrorMessages.CategoryNotFound, HttpStatusCode.NotFound);

            await categoriesRepo.Delete(id);
            await categoriesRepo.Save();
        }
    }
}
