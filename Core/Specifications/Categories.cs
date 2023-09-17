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
    public static class Categories
    {
        public class GetAll : Specification<Category>
        {
            public GetAll()
            {
                Query
                    .OrderBy (c => c.Name)
                   .Include(c => c.Products);
            }
        }
        public class ById : Specification<Category>
        {
            public ById(int id)
            {
                Query
                    .Where(c => c.Id == id)
                   .Include(c => c.Products);
            }
        }
    }
}
