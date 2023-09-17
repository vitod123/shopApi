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
    public class ProductsService : IProductsService
    {

        private readonly IRepository<Product> productsRepo;
        private readonly IMapper mapper;

        public ProductsService(IRepository<Product> productsRepo, IMapper mapper)
        {
            this.productsRepo = productsRepo;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var result = await productsRepo.GetAll();

            return mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public async Task<ProductDto?> GetById(int id)
        {
            Product? item = await productsRepo.GetItemBySpec(new Products.ById(id));

            if (item == null)
                throw new HttpException(ErrorMessages.ProductNotFound, HttpStatusCode.NotFound);

            return mapper.Map<ProductDto>(item);
        }

        public async Task Edit(ProductDto product)
        {
            await productsRepo.Update(mapper.Map<Product>(product));
            await productsRepo.Save();
        }

        public async Task Create(ProductDto product)
        {
            await productsRepo.Insert(mapper.Map<Product>(product));
            await productsRepo.Save();
        }

        public async Task Delete(int id)
        {
            if (await productsRepo.GetById(id) == null)
                throw new HttpException(ErrorMessages.ProductNotFound, HttpStatusCode.NotFound);

            await productsRepo.Delete(id);
            await productsRepo.Save();
        }

        public async Task<IEnumerable<ProductDto>> Order(string order)
        {
            IEnumerable<Product> result;
            if (order == "orderbyname" || order == "byname" || order == "name")
                result = await productsRepo.GetListBySpec(new Products.OrderByName());
            else if (order == "orderbyprice" || order == "byprice" || order == "price")
                result = await productsRepo.GetListBySpec(new Products.OrderByPrice());
            else if (order == "orderbydescendingprice" || order == "bydescendingprice" || order == "descendingprice")
                result = await productsRepo.GetListBySpec(new Products.OrderByDescendingPrice());
            else
                result = await productsRepo.GetListBySpec(new Products.OrderByRating());

            return mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public async Task<IEnumerable<ProductDto>> Search(string search)
        {
            var result = await productsRepo.GetListBySpec(new Products.GetAll());
            result = result.Where(c => c.Name.ToLower().Contains(search));
            return mapper.Map<IEnumerable<ProductDto>>(result);
        }
    }
}
