using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
    public class Store
    {
        [Key]
        [Display(Name =("Store Id"))]
        public int StoreId { get; set; }
        [Display(Name =("Store Name"))]
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
