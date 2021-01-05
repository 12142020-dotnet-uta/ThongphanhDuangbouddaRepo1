using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace TrollStore.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
