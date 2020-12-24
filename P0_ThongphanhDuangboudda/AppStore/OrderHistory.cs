
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace AppStore
{
    public class OrderHistory 
    {
        //TODO
        [Key]
        public int OrderId{get;set;}
        public int CustumerId{get; set;}
        public string ProductName {get; set;}  
        public string ProductDescription{get; set;}
        public string Category{get; set;}
        public decimal Price {get; set;}
        public int Quantity{get; set;}
        public string StoreLocation{ get; set;}

        
    }
}