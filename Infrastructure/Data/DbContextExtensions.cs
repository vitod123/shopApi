using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class DbContextExtensions
    {
        public static void SeedBasket(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Basket>().HasData(new[]
            //{
            //    new Basket()
            //    {
            //        Id = 1,
            //        UserId ="gay",
            //        ProductId = 1,
            //    },
            //    new Basket()
            //    {
            //        Id = 1,
            //        UserId ="gay",
            //        ProductId = 1,
            //    },
            //    new Basket()
            //    {
            //        Id = 1,
            //        UserId ="gay",
            //        ProductId = 1,
            //    }
            //});
        }

        public static void SeedCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new[]
            {
                new Category()
                {
                    Id = 1,
                    Name = "Sport"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Laptop and PC"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Phones"
                }
            });
        }
        
        public static void SeedFavorite(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Favorite>().HasData(new[]
            //{
            //    new Favorite()
            //    {
            //        Id = 1,
            //        UserId ="gay",
            //        ProductId = 1,
            //    },
            //    new Favorite()
            //    {
            //        Id = 1,
            //        UserId ="gay",
            //        ProductId = 1,
            //    },
            //    new Favorite()
            //    {
            //        Id = 1,
            //        UserId ="gay",
            //        ProductId = 1,
            //    }
            //});
        }

        public static void SeedProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new[]
            {
                new Product()
                {
                    Id = 1,
                    Name = "Велосипед Ghost Roket 5.7+ 27,5\" рама M 2019 (18RO1002)",
                    Price = 1000,
                    Description = "Ghost Rocket 5.7+  – это велосипед для настоящих любителей путешествовать и тех, кто жить не можете без приключений. Геометрия рамы и острый угол рулевого стакана делают его отличным вариантом для долгой и уверенной езды по любым грунтам и рельефам, а вилка с ходом 130мм и ультра широкие покрышки – придают этому байку еще больше комфорта и универсальности.  ",
                    Rating = 4,
                    Count = 3,
                    CategoryId = 1,
                    ImagePath = "https://content1.rozetka.com.ua/goods/images/big/56550214.png"
                },
                new Product()
                {
                    Id = 2,
                    Name = "Dell G15",
                    Price = 1500,
                    Description = "The Dell G15 (2022) is a 15.6-inch budget gaming laptop. It's available with an Intel Core i5-12500H or i7-12700H CPU and various NVIDIA GeForce GPUs, from an RTX 3050 to an RTX 3070 Ti. There are also multiple display options, including an FHD (1920 x 1080) 120Hz, an FHD 165Hz, and a QHD (2560 x 1440) 240Hz display.",
                    Rating = 5,
                    Count = 10,
                    CategoryId = 2,
                    ImagePath = "https://content.rozetka.com.ua/goods/images/big/343097445.jpg"
                },
                new Product()
                {
                    Id = 3,
                    Name = "Apple iPhone 14 128GB Midnight (MPUF3RX/A)",
                    Price = 800,
                    Description = "Экран (6.1, OLED (Super Retina XDR), 2532x1170) / Apple A15 Bionic / двойная основная камера: 12 Мп + 12 Мп, фронтальная камера: 12 Мп / 128 ГБ встроенной памяти / 3G / LTE / 5G / GPS / Nano-SIM / iOS 16",
                    Rating = 3,
                    Count = 6,
                    CategoryId = 3,
                    ImagePath = "https://content.rozetka.com.ua/goods/images/big/33744459.jpg"
                }
            });
        }


        //public static void SeedUser(this ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(new[]
        //    {
        //        new User()
        //        {
        //            UserName = "soneta666",
        //            Email = "ssdjk2323@gmail.com",
        //            PhoneNumber = "0932323313",
        //            Password = "qwerty123",
        //            Birthday = new DateTime(),
        //            Photo = "https://play-lh.googleusercontent.com/UjaAdTYsArv7zAJbqGWjQw2ftuOtnAlvokffC3TQQ2K12mwk0YdXUF2wZBTBA2kDZIk",
        //            FirstName = "Sofiia",
        //            LastName = "Stepaniuk",
        //        },
        //        new User()
        //        {
        //            UserName = "jakeentony",
        //            Email = "jake20@gmail.com",
        //            PhoneNumber = "0932003342",
        //            Password = "pass123",
        //            Birthday = new DateTime(),
        //            Photo = "https://static.wikia.nocookie.net/cartoon-network/images/3/3b/Jakesalad.png/revision/latest?cb=20141215195941&path-prefix=pl",
        //            FirstName = "Yevgen",
        //            LastName = "Parakon",
        //        },
        //        new User()
        //        {
        //            UserName = "vitod123",
        //            Email = "vitalik509@gmail.com",
        //            PhoneNumber = "0935588942",
        //            Password = "pasiNew123@",
        //            Birthday = new DateTime(),
        //            Photo = "https://images.wallpaperscraft.ru/image/single/siluet_luna_lodka_135277_1920x1080.jpg",
        //            FirstName = "Vitalii",
        //            LastName = "Marchuk",
        //        }
        //    });
        //}
    }

}