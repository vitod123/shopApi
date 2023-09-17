using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto?> GetByUserName(string userName);
        Task Create(UserDto user);
        Task Edit(UserDto user);
        Task Delete(int id);
    }
}
