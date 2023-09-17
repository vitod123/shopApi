using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<IEnumerable<ProductDto>> Order(string order);
        Task<IEnumerable<ProductDto>> Search(string search);
        Task<ProductDto?> GetById(int id);
        Task Create(ProductDto product);
        Task Edit(ProductDto product);
        Task Delete(int id);
    }
}