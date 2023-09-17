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
    public static class Baskets
    {
        public class GetAll : Specification<Basket>
        {
            public GetAll()
            {
                Query
                    .Include(b => b.User)
                    .Include(b => b.Product);
            }
        }
        public class ById : Specification<Basket>
        {
            public ById(int id)
            {
                Query
                    .Where(b => b.Id == id)
                    .Include(b => b.User)
                    .Include(b => b.Product);
            }
        }
        public class ByUserName : Specification<Basket>
        {
            public ByUserName(string userName)
            {
                Query
                    .Include(i => i.User)
                    .Where(i => i.User.UserName == userName)
                    .Include(i => i.Product);
            }
        }
    }
}
