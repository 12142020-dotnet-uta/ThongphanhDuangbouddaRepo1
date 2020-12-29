
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace AppStore.Models
{
    public class OrderHistory
    {
        //TODO
        [Key]
        public int OrderId{get;set;}

        public int CustomerId{get; set;}
        public Customer customer{get; set;}

        public string ProductName {get; set;}  
        public string ProductDescription{get; set;}
        public string Category{get; set;}
        public decimal Price {get; set;}
        public int Quantity{get; set;}
        public DateTime OrderDate{ get; set;}
        public int StoreId{ get; set;}
        public Store store {get; set;}
        

        
    }
}