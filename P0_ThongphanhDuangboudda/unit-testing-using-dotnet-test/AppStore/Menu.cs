using System;
using System.Collections.Generic;
using AppStore.DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace AppStore
{
    public class Menu
    {
     
        
        /*
        * PURPOSE : View store information
        *
        * RETURN : String of store information
        *
        *F*/

        public string viewStore(){
            string str = "";
            using(var db = new AppStoreContext()){
                var stores = db.Stores;
                foreach(var store in stores ){
                    str =  str + store.StoreId +"\t" + store.StoreName + "\t" + store.Address + "\n";
                }
            }

            return str;
        }
         /*
        * PURPOSE : View all products in the cart
        *
        * RETURN : String of product information
        *
        *F*/
        public string ViewCart(List<Product> carts){
            string str ="";
            foreach(var product in carts){
                str = str + product.ProductName + "\t" + product.Quantity + "\t" + product.Quantity * product.Price + "\n";
            }
            
            return str;
        }
         /*
        * PURPOSE : View personal order history
        *
        * RETURN : String of Earliest time
        *
        *F*/
        public string ViewOrderByEarliest(int customerId){
            string str = "";
            using(var db = new AppStoreContext()){
                var orders = db.OrderHistories
                             .Where(x =>x.CustomerId == customerId)
                             .OrderBy(x =>x.OrderDate);
                foreach(var order in orders){
                 str = str + order.ProductName + "\t\t   " + order.Quantity + "\t\t  " 
                 + order.Price + order.StoreId + "        "  + order.StoreId + "\t " + order.OrderDate  + "\n";
 
                }
            }
            if(str.Length == 0){ str = "No Record";}
            return str;

        }
         /*
        * PURPOSE : View order history by latest time
        *
        * RETURN : String of order history by latest time
        *
        *F*/

        public string ViewOrderByLatest(int customerId){
            string str = "";
            using(var db = new AppStoreContext()){
                var orders = db.OrderHistories
                             .Where(x =>x.CustomerId == customerId)
                             .OrderByDescending(x =>x.OrderDate);
                foreach(var order in orders){
                 str = str + order.ProductName + "\t\t   " + order.Quantity + "\t\t  " 
                 + order.Price + order.StoreId + "        "  + order.StoreId + "\t " + order.OrderDate  + "\n";
 
                }
            }
            if(str.Length == 0){ str = "No Record";}
            return str;

        }
        /*
        * PURPOSE : View order history by cheapest
        *
        * RETURN : String of order history by cheapest
        *
        *F*/
        public string ViewOrderByCheapest(int customerId){
            string str = "";
            using(var db = new AppStoreContext()){
                var orders = db.OrderHistories
                             .Where(x =>x.CustomerId == customerId)
                             .OrderBy(x =>x.Price);
                foreach(var order in orders){
                 str = str + order.ProductName + "\t\t   " + order.Quantity + "\t\t  " 
                 + order.Price + order.StoreId + "        "  + order.StoreId + "\t " + order.OrderDate  + "\n";
 
                }
            }
            if(str.Length == 0){ str = "No Record";}
            return str;

        }
        /*
        * PURPOSE : View order history by most expensive
        *
        * RETURN : String of order history by most expensive
        *
        *F*/

        public string ViewOrderByMostExpensive(int customerId){
            string str = "";
            using(var db = new AppStoreContext()){
                var orders = db.OrderHistories
                             .Where(x =>x.CustomerId == customerId)
                             .OrderByDescending(x =>x.Price);
                foreach(var order in orders){
                 str = str + order.ProductName + "\t\t   " + order.Quantity + "\t\t  " 
                 + order.Price + order.StoreId + "        "  + order.StoreId + "\t " + order.OrderDate  + "\n";
 
                }
            }
            if(str.Length == 0){ str = "No Record";}
            return str;

        }
    }
}