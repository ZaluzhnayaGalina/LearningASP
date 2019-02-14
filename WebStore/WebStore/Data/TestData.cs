using System.Collections.Generic;
using WebStore.DomainEntities.Entities;

namespace WebStore.Data
{
    public class TestData
    {
        public static List<Brand> Brands = new List<Brand> {
         new Brand()
                {
                    Id = 1,
                    Name = "Acne",
                    OrderNumber = 0
                },
                new Brand()
                {
                    Id = 2,
                    Name = "Grüne Erde",
                    OrderNumber = 1
                },
                new Brand()
                {
                    Id = 3,
                    Name = "Albiro",
                    OrderNumber = 2
                },
                new Brand()
                {
                    Id = 4,
                    Name = "Ronhill",
                    OrderNumber = 3
                },
                new Brand()
                {
                    Id = 5,
                    Name = "Oddmolly",
                    OrderNumber = 4
                },
                new Brand()
                {
                    Id = 6,
                    Name = "Boudestijn",
                    OrderNumber = 5
                },
                new Brand()
                {
                    Id = 7,
                    Name = "Rösch creative culture",
                    OrderNumber = 6
                },
};
        public static List<Section> Sections = new List<Section> { new Section()
                {
                    Id = 1,
                    Name = "Sportswear",
                    OrderNumber = 0,
                    ParentId = null
                },
                new Section()
                {
                    Id = 2,
                    Name = "Nike",
                    OrderNumber = 0,
                    ParentId = 1
                },
                new Section()
                {
                    Id = 3,
                    Name = "Under Armour",
                    OrderNumber = 1,
                    ParentId = 1
                },
                new Section()
                {
                    Id = 4,
                    Name = "Adidas",
                    OrderNumber = 2,
                    ParentId = 1
                },
                new Section()
                {
                    Id = 5,
                    Name = "Puma",
                    OrderNumber = 3,
                    ParentId = 1
                },
                new Section()
                {
                    Id = 6,
                    Name = "ASICS",
                    OrderNumber = 4,
                    ParentId = 1
                },
                new Section()
                {
                    Id = 7,
                    Name = "Mens",
                    OrderNumber = 1,
                    ParentId = null
                },
                new Section()
                {
                    Id = 8,
                    Name = "Fendi",
                    OrderNumber = 0,
                    ParentId = 7
                },
                new Section()
                {
                    Id = 9,
                    Name = "Guess",
                    OrderNumber = 1,
                    ParentId = 7
                },
                new Section()
                {
                    Id = 10,
                    Name = "Valentino",
                    OrderNumber = 2,
                    ParentId = 7
                },
                new Section()
                {
                    Id = 11,
                    Name = "Dior",
                    OrderNumber = 3,
                    ParentId = 7
                },
                new Section()
                {
                    Id = 12,
                    Name = "Versace",
                    OrderNumber = 4,
                    ParentId = 7
                },
                new Section()
                {
                    Id = 13,
                    Name = "Armani",
                    OrderNumber = 5,
                    ParentId = 7
                },
                new Section()
                {
                    Id = 14,
                    Name = "Prada",
                    OrderNumber = 6,
                    ParentId = 7
                },
                new Section()
                {
                    Id = 15,
                    Name = "Dolce and Gabbana",
                    OrderNumber = 7,
                    ParentId = 7
                },
                new Section()
                {
                    Id = 16,
                    Name = "Chanel",
                    OrderNumber = 8,
                    ParentId = 7
                },
                new Section()
                {
                    Id = 17,
                    Name = "Gucci",
                    OrderNumber = 1,
                    ParentId = 7
                },
                new Section()
                {
                    Id = 18,
                    Name = "Womens",
                    OrderNumber = 2,
                    ParentId = null
                },
                new Section()
                {
                    Id = 19,
                    Name = "Fendi",
                    OrderNumber = 0,
                    ParentId = 18
                },
                new Section()
                {
                    Id = 20,
                    Name = "Guess",
                    OrderNumber = 1,
                    ParentId = 18
                },
                new Section()
                {
                    Id = 21,
                    Name = "Valentino",
                    OrderNumber = 2,
                    ParentId = 18
                },
                new Section()
                {
                    Id = 22,
                    Name = "Dior",
                    OrderNumber = 3,
                    ParentId = 18
                },
                new Section()
                {
                    Id = 23,
                    Name = "Versace",
                    OrderNumber = 4,
                    ParentId = 18
                },
                new Section()
                {
                    Id = 24,
                    Name = "Kids",
                    OrderNumber = 3,
                    ParentId = null
                },
                new Section()
                {
                    Id = 25,
                    Name = "Fashion",
                    OrderNumber = 4,
                    ParentId = null
                },
                new Section()
                {
                    Id = 26,
                    Name = "Households",
                    OrderNumber = 5,
                    ParentId = null
                },
                new Section()
                {
                    Id = 27,
                    Name = "Interiors",
                    OrderNumber = 6,
                    ParentId = null
                },
                new Section()
                {
                    Id = 28,
                    Name = "Clothing",
                    OrderNumber = 7,
                    ParentId = null
                },
                new Section()
                {
                    Id = 29,
                    Name = "Bags",
                    OrderNumber = 8,
                    ParentId = null
                },
                new Section()
                {
                    Id = 30,
                    Name = "Shoes",
                    OrderNumber = 9,
                    ParentId = null
                }
            };
        public static List<Product> Products { get; } = new List<Product>
        {
            new Product { Id = 1, Name = "Easy Polo Black Edition", Price = 1025, ImageUrl = "product1.jpg", Order = 0, SectionId = 2, BrandId = 1 },
            new Product { Id = 2, Name = "Easy Polo Black Edition", Price = 1025, ImageUrl = "product2.jpg", Order = 1, SectionId = 2, BrandId = 1 },
            new Product { Id = 3, Name = "Easy Polo Black Edition", Price = 1025, ImageUrl = "product3.jpg", Order = 2, SectionId = 2, BrandId = 1 },
            new Product { Id = 4, Name = "Easy Polo Black Edition", Price = 1025, ImageUrl = "product4.jpg", Order = 3, SectionId = 2, BrandId = 1 },
            new Product { Id = 5, Name = "Easy Polo Black Edition", Price = 1025, ImageUrl = "product5.jpg", Order = 4, SectionId = 2, BrandId = 2 },
            new Product { Id = 6, Name = "Easy Polo Black Edition", Price = 1025, ImageUrl = "product6.jpg", Order = 5, SectionId = 2, BrandId = 1 },
            new Product { Id = 7, Name = "Easy Polo Black Edition", Price = 1025, ImageUrl = "product7.jpg", Order = 6, SectionId = 2, BrandId = 1 },
            new Product { Id = 8, Name = "Easy Polo Black Edition", Price = 1025, ImageUrl = "product8.jpg", Order = 7, SectionId = 25, BrandId = 1 },
            new Product { Id = 9, Name = "Easy Polo Black Edition", Price = 1025, ImageUrl = "product9.jpg", Order = 8, SectionId = 25, BrandId = 1 },
            new Product { Id = 10, Name = "Easy Polo Black Edition", Price = 1025, ImageUrl = "product10.jpg", Order = 9, SectionId = 25, BrandId = 3 },
            new Product { Id = 11, Name = "Easy Polo Black Edition", Price = 1025, ImageUrl = "product11.jpg", Order = 10, SectionId = 25, BrandId = 3 },
            new Product { Id = 12, Name = "Easy Polo Black Edition", Price = 1025, ImageUrl = "product12.jpg", Order = 11, SectionId = 25, BrandId = 3 },
        };
    };
    
}
