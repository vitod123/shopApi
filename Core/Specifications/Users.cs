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
    public static class Users
    {
        public class GetAll : Specification<User>
        {
            public GetAll()
            {
                Query
                    .Include(u => u.Baskets)
                    .Include(u => u.Favorites);
            }
        }
        public class ByUserName : Specification<User>
        {
            public ByUserName(string userName)
            {
                Query
                    .Where(u => u.UserName == userName)
                    .Include(u => u.Baskets)
                    .Include(u => u.Favorites);
            }
        }
    }
}
