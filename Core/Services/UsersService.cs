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
    public class UsersService : IUsersService
    {

        private readonly IRepository<User> usersRepo;
        private readonly IMapper mapper;

        public UsersService(IRepository<User> usersRepo, IMapper mapper)
        {
            this.usersRepo = usersRepo;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var result = await usersRepo.GetListBySpec(new Users.GetAll());

            return mapper.Map<IEnumerable<UserDto>>(result);
        }

        public async Task<UserDto?> GetByUserName(string userName)
        {
            User? item = await usersRepo.GetItemBySpec(new Users.ByUserName(userName));

            if (item == null)
                throw new HttpException(ErrorMessages.UserByIdNotFound, HttpStatusCode.NotFound);

            return mapper.Map<UserDto>(item);
        }

        public async Task Edit(UserDto user)
        {
            await usersRepo.Update(mapper.Map<User>(user));
            await usersRepo.Save();
        }

        public async Task Create(UserDto user)
        {
            await usersRepo.Insert(mapper.Map<User>(user));
            await usersRepo.Save();
        }

        public async Task Delete(int id)
        {
            if (await usersRepo.GetById(id) == null)
                throw new HttpException(ErrorMessages.UserByIdNotFound, HttpStatusCode.NotFound);

            await usersRepo.Delete(id);
            await usersRepo.Save();
        }
    }
}
