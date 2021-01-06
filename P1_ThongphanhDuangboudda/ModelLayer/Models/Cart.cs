using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ModelLayer.Models
{
    public class Cart
    {
        private int cartId;
        [Key]
        public int CartId {
            get => cartId;
            set => cartId = value;
        }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int StoreId { get; set; }
        public Store store { get; set; }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
       

    }
}
