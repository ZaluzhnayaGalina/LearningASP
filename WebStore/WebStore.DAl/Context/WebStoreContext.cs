﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebStore.DomainEntities;
using WebStore.DomainEntities.Entities;

namespace WebStore.DAL.Context
{
    public class WebStoreContext: IdentityDbContext<User>
    {
        public WebStoreContext(DbContextOptions options): base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
