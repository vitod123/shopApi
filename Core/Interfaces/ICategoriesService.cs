using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs;

namespace Core.Interfaces
{
    public interface ICategoriesService
    {
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto?> GetById(int id);
        Task Create(CategoryDto category);
        Task Edit(CategoryDto category);
        Task Delete(int id);
    }
}
