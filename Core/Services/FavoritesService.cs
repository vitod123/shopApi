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
    public class FavoritesService : IFavoritesService
    {

        private readonly IRepository<Favorite> favoritesRepo;
        private readonly IMapper mapper;

        public FavoritesService(IRepository<Favorite> favoritesRepo, IMapper mapper)
        {
            this.favoritesRepo = favoritesRepo;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<FavoriteDto>> GetAll()
        {
            var result = await favoritesRepo.GetListBySpec(new Favorites.GetAll());

            return mapper.Map<IEnumerable<FavoriteDto>>(result);
        }

        public async Task<FavoriteDto?> GetById(int id)
        {
            Favorite? item = await favoritesRepo.GetItemBySpec(new Favorites.ById(id));

            if (item == null)
                throw new HttpException(ErrorMessages.FavoriteNotFound, HttpStatusCode.NotFound);

            return mapper.Map<FavoriteDto>(item);
        }
        public async Task<IEnumerable<FavoriteDto>?> GetByUserName(string userName)
        {
            var result = await favoritesRepo.GetListBySpec(new Favorites.ByUserName(userName));

            if (result == null)
                throw new HttpException(ErrorMessages.FavoriteNotFound, HttpStatusCode.NotFound);

            return mapper.Map<IEnumerable<FavoriteDto>>(result);
        }

        public async Task Edit(FavoriteDto favorite)
        {
            await favoritesRepo.Update(mapper.Map<Favorite>(favorite));
            await favoritesRepo.Save();
        }

        public async Task Create(FavoriteDto favorite)
        {
            await favoritesRepo.Insert(mapper.Map<Favorite>(favorite));
            await favoritesRepo.Save();
        }

        public async Task Delete(int id)
        {
            if (await favoritesRepo.GetById(id) == null)
                throw new HttpException(ErrorMessages.FavoriteNotFound, HttpStatusCode.NotFound);

            await favoritesRepo.Delete(id);
            await favoritesRepo.Save();
        }
    }
}
