using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public uint Rating { get; set; }
        public uint Count { get; set; }
        public uint CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public string ImagePath { get; set; }

    }
}
