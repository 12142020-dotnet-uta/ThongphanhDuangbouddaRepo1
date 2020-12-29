using System.Collections.Generic;
using AppStore.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
namespace AppStore.DAL
{
    public class OrderHistoryDAL
    {
        public string GetOrderSuggestions(int customerId){
            var rand = new Random();
            string str = "";
            int electronic = 0;
            int grocery = 0;
            int clothing = 0;
            //min inclued, max exclude
            int number = rand.Next(0,5);
            using(var db = new AppStoreContext()){
                var orderHis = db.OrderHistories
                    .Where(x =>x.CustomerId == customerId)
                    .AsNoTracking()
                    .ToList();
                foreach(var order in orderHis){
                    if(order.Category == "Electronic"){
                        electronic++;
                    }else if( order.Category == "Clothing"){
                        clothing++;
                    }else if( order.Category == "Grocery"){
                        grocery++;
                    }
                }
                
                if(electronic> grocery){ 
                    var prouct = db.Products
                                .Where(p => p.Category == "Electronic")
                                .AsNoTracking()
                                .FirstOrDefault();
                    str = prouct.ProductName + "\t" + prouct.Price + "\n";
                }else if(clothing> grocery){
                    var prouct = db.Products
                                .Where(p => p.Category == "Clothing")
                                .AsNoTracking()
                                .FirstOrDefault();
                    str = prouct.ProductName + "\t" + prouct.Price + "\n";

                }else{
                    var prouct = db.Products
                                .Where(p => p.Category == "Grocery")
                                .AsNoTracking()
                                .FirstOrDefault();
                    str = prouct.ProductName + "\t" + prouct.Price + "\n";

                }

            }
            if(str.Length == 0){str = "No Record";}
            return str;
    
                
        }

      
        
    }
}