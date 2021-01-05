using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//
using System.ComponentModel.DataAnnotations.Schema;

namespace TrollStore.Models
{
    public class OrderHistory
    {
        //TODO
        [Key]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }
        public Customer customer { get; set; }

        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public int StoreId { get; set; }
        public Store store { get; set; }


    }
}
