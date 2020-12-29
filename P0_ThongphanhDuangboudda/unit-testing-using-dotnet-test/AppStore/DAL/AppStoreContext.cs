using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AppStore.Models;

namespace AppStore.DAL
 {
    public class AppStoreContext: DbContext
    {
        public DbSet<Customer> Customers{get; set;}
        public DbSet<Store> Stores {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<OrderHistory> OrderHistories { get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Store_DB;Trusted_Connection = True;");
        
        
    }
}