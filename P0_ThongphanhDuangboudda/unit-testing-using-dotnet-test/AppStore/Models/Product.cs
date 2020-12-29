using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using AppStore.Models;


namespace AppStore
{
    public class Product
    {
        [Key]
        public int  ProductID {get; set;}

        public string ProductName {get; set;}  
        public string ProductDescription{get; set;}
        public string Category{get; set;}
        public decimal Price {get; set;}
        public int Quantity{get; set;}
        public int StoreId{get; set;}
        public Store store{get;set;}
        
    }
}