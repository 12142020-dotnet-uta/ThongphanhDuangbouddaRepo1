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
        * PURPOSE : Input line of text from keyboard
        *
        * RETURN :  VALID_DATA = valid read
        *          (see keyboard.h for the rest)
        *
        * NOTES :   Unknown characters returned as '*'
        *           Backspace is the only editing allowed.
        *F*/
        
        /*
        * PURPOSE : Input line of text from keyboard
        *
        * RETURN :  VALID_DATA = valid read
        *          (see keyboard.h for the rest)
        *
        * NOTES :   Unknown characters returned as '*'
        *           Backspace is the only editing allowed.
        *F*/
        public void GetLogInMenue(){
            Console.WriteLine("Presse 1. \t ");

        }
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
        public string ViewCart(List<Product> carts){
            string str ="";
            foreach(var product in carts){
                str = str + product.ProductName + "\t" + product.Quantity + "\t" + product.Quantity * product.Price + "\n";
            }
            
            return str;
        }
        public string ViewOrderByEarliest(int customerId){
            string str = "";
            using(var db = new AppStoreContext()){
                var orders = db.OrderHistories
                             .Where(x =>x.CustumerId == customerId)
                             .OrderBy(x =>x.OrderDate);
                foreach(var order in orders){
                 str = str + order.ProductName + "\t\t   " + order.Quantity + "\t\t  " 
                 + order.Price + order.StoreId + "        "  + order.StoreId + "\t " + order.OrderDate  + "\n";
 
                }
            }
            if(str.Length == 0){ str = "No Record";}
            return str;

        }

        public string ViewOrderByLatest(int customerId){
            string str = "";
            using(var db = new AppStoreContext()){
                var orders = db.OrderHistories
                             .Where(x =>x.CustumerId == customerId)
                             .OrderByDescending(x =>x.OrderDate);
                foreach(var order in orders){
                 str = str + order.ProductName + "\t\t   " + order.Quantity + "\t\t  " 
                 + order.Price + order.StoreId + "        "  + order.StoreId + "\t " + order.OrderDate  + "\n";
 
                }
            }
            if(str.Length == 0){ str = "No Record";}
            return str;

        }

        public string ViewOrderByCheapest(int customerId){
            string str = "";
            using(var db = new AppStoreContext()){
                var orders = db.OrderHistories
                             .Where(x =>x.CustumerId == customerId)
                             .OrderBy(x =>x.Price);
                foreach(var order in orders){
                 str = str + order.ProductName + "\t\t   " + order.Quantity + "\t\t  " 
                 + order.Price + order.StoreId + "        "  + order.StoreId + "\t " + order.OrderDate  + "\n";
 
                }
            }
            if(str.Length == 0){ str = "No Record";}
            return str;

        }

        public string ViewOrderByMostExpensive(int customerId){
            string str = "";
            using(var db = new AppStoreContext()){
                var orders = db.OrderHistories
                             .Where(x =>x.CustumerId == customerId)
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