using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Category { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; }
        public int StoreId { get; set; }
        public Store store { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageString { get; set; }

    }
}
