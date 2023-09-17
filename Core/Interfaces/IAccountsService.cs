using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.User;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IAccountsService
    {
        Task<User> Get(string id);
        Task<LoginResponseDto> Login(LoginDto dto);
        Task Register(RegisterDto dto);
        Task Logout();
    }
}
