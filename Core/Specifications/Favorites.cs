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
    public static class Favorites
    {
        public class GetAll : Specification<Favorite>
        {
            public GetAll()
            {
                Query
                    .Include(c => c.Product)
                    .Include(c => c.User);
            }
        }
        public class ById : Specification<Favorite>
        {
            public ById(int id)
            {
                Query
                    .Where(f => f.Id == id)
                    .Include(c => c.Product)
                    .Include(c => c.User);
            }
        }
        public class ByUserName : Specification<Favorite>
        {
            public ByUserName(string userName)
            {
                Query
                    .Include(f => f.User)
                    .Where(f => f.User.UserName == userName)
                    .Include(f => f.Product);
            }
        }
    }
}
