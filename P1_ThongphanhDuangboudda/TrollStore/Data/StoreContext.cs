using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrollStore.Models;
{

}

namespace TrollStore.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
             : base(options)
        {
           
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<TicketNumber> TicketNumbers { get; set; }

    }
}
