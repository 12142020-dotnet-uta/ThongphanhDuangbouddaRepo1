using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace TrollStore.Models
{
    public class Cart
    {
        private int cartId;
        [Key]
        public int CartId {
            get => cartId;
            set => cartId = value;
        }
        public int StoreId { get; set; }
        public Store store { get; set; }

    }
}
