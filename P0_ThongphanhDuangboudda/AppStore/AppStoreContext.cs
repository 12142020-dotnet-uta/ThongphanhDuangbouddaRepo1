using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppStore
 {
    public class AppStoreContext: DbContext
    {
        public DbSet<Store> Stores {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<OrderHistory> OrderHistories { get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=StoreDB;Trusted_Connection = True;");
        
        
    }
}