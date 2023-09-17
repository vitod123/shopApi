using Ardalis.Specification;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Core.Specifications
{
    public static class Products
    {
        public class GetAll : Specification<Product>
        {
            public GetAll()
            {
                Query
                    .Include(p => p.Favorites)
                    .Include(p => p.Baskets)
                    .Include(p => p.Category);
            }
        }
        public class OrderByRating : Specification<Product>
        {
            public OrderByRating()
            {
                Query
                    .OrderBy(p => p.Rating)
                    .Include(p => p.Favorites)
                    .Include(p => p.Baskets)
                    .Include(p => p.Category);
            }
        }
        public class OrderByName : Specification<Product>
        {
            public OrderByName()
            {
                Query
                    .OrderBy(p => p.Name)
                    .Include(p => p.Favorites)
                    .Include(p => p.Baskets)
                    .Include(p => p.Category);
            }
        }
        public class OrderByPrice : Specification<Product>
        {
            public OrderByPrice()
            {
                Query
                    .OrderBy(p => p.Price)
                    .Include(p => p.Favorites)
                    .Include(p => p.Baskets)
                    .Include(p => p.Category);
            }
        }
        public class OrderByDescendingPrice : Specification<Product>
        {
            public OrderByDescendingPrice()
            {
                Query
                    .OrderByDescending(p => p.Price)
                    .Include(p => p.Favorites)
                    .Include(p => p.Baskets)
                    .Include(p => p.Category);
            }
        }
        public class ById : Specification<Product>
        {
            public ById(int id)
            {
                Query
                    .Where(p => p.Id == id)
                    .Include(p => p.Favorites)
                    .Include(p => p.Baskets)
                    .Include(p => p.Category);
            }
        }
    }
}
