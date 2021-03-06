using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Models;

namespace RepositoryLayer
 {
    public class AppStoreContext: DbContext
    {

        
        public DbSet<Customer> Customers{get; set;}
        public DbSet<Store> Stores {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<OrderHistory> OrderHistories { get; set;}
        public DbSet<TicketNumber> TicketNumbers { get; set; }
        public DbSet<Cart> Carts { get; set; }
       
        public AppStoreContext() 
        {

        }
        
        public AppStoreContext(DbContextOptions<AppStoreContext> options)
               : base(options)
        {
        }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=AppStore;Trusted_Connection = True;");
            }

        }
            
        
       
    }
}