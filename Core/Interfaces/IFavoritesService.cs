using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IFavoritesService
    {
        Task<IEnumerable<FavoriteDto>> GetAll();
        Task<IEnumerable<FavoriteDto>?> GetByUserName(string userName);
        Task<FavoriteDto?> GetById(int id);
        Task Create(FavoriteDto favorite);
        Task Edit(FavoriteDto favorite);
        Task Delete(int id);
    }
}
