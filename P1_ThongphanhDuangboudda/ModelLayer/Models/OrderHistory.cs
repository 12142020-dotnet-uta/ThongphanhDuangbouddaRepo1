using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer.Models
{
    public class OrderHistory
    {
        //TODO
        [Key]
        [Display(Name =("Order Id"))]
        public int OrderId { get; set; }
        [Display(Name =("Customer Id"))]
        public int CustomerId { get; set; }
        public Customer customer { get; set; }
        [Display(Name =("Product Name"))]
        public string ProductName { get; set; }
        [Display(Name =("Product Description"))]
        public string ProductDescription { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public int StoreId { get; set; }
        public Store store { get; set; }


    }
}
