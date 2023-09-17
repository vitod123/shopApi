using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBasketsService
    {
        Task<IEnumerable<BasketDto>> GetAll();
        Task<IEnumerable<BasketDto>?> GetByUserName(string userName);
        Task<BasketDto> GetById(int id);
        Task Create(BasketDto basket);
        Task Edit(BasketDto basket);
        Task Delete(int id);
    }
}
