using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name ="Customer Id")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int StoreId { get; set; }
        public Store store { get; set; }
        [Display(Name ="Product Id")]
        public int ProductID { get; set; }
        [Display(Name =("Product Name"))]
        public string ProductName { get; set; }
        [Display(Name =("Preduct Description"))]
        public string ProductDescription { get; set; }
        public string Category { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
       

    }
}
