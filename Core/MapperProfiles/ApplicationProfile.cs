using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using Core.DTOs;
using Core.Entities;

namespace Core.MapperProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Basket, BasketDto>()
                .ForMember(b => b.User, opt => opt.MapFrom(b => b.User))
                .ForMember(b => b.Product, opt => opt.MapFrom(b => b.Product));
            CreateMap<BasketDto, Basket>();

            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Favorite, FavoriteDto>()
                .ForMember(f => f.User, opt => opt.MapFrom(f => f.User))
                .ForMember(f => f.Product, opt => opt.MapFrom(f => f.Product));
            CreateMap<FavoriteDto, Favorite>();

            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Product, ProductDto>()
                .ForMember(p => p.Category, opt => opt.MapFrom(p => p.Category));
            CreateMap<ProductDto, Product>();
            
            // All right 😘
        }
    }
}
