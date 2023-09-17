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
    public class BasketsService :  IBasketsService
    {

        private readonly IRepository<Basket> basketsRepo;
        private readonly IMapper mapper;

        public BasketsService(IRepository<Basket> basketsRepo, IMapper mapper)
        {
            this.basketsRepo = basketsRepo;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<BasketDto>> GetAll()
        {
            var result = await basketsRepo.GetListBySpec(new Baskets.GetAll());

            return mapper.Map<IEnumerable<BasketDto>>(result);
        }

        public async Task<BasketDto?> GetById(int id)
        {
            Basket? item = await basketsRepo.GetItemBySpec(new Baskets.ById(id));

            if (item == null)
                throw new HttpException(ErrorMessages.BasketNotFound, HttpStatusCode.NotFound);

            return mapper.Map<BasketDto>(item);
        }
        public async Task<IEnumerable<BasketDto>?> GetByUserName(string userName)
        {
            var result = await basketsRepo.GetListBySpec(new Baskets.ByUserName(userName));

            if (result == null)
                throw new HttpException(ErrorMessages.BasketNotFound, HttpStatusCode.NotFound);

            return mapper.Map<IEnumerable<BasketDto>>(result);
        }

        public async Task Edit(BasketDto basket)
        {
            await basketsRepo.Update(mapper.Map<Basket>(basket));
            await basketsRepo.Save();
        }

        public async Task Create(BasketDto basket)
        {
            await basketsRepo.Insert(mapper.Map<Basket>(basket));
            await basketsRepo.Save();
        }

        public async Task Delete(int id)
        {
            if (await basketsRepo.GetById(id) == null)
                throw new HttpException(ErrorMessages.BasketNotFound, HttpStatusCode.NotFound);

            await basketsRepo.Delete(id);
            await basketsRepo.Save();
        }
    }
}
