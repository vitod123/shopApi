using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class BasketDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public uint ProductId { get; set; }
        public UserDto? User { get; set; }
        public ProductDto? Product { get; set; }
    }
}
