using System;
using System.Collections.Generic;
using AppStore.DAL;
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
        public string viewGeneralOrderHistory(int customerID){
            string str = "";
            return str;
        }
        public  string ViewSpicificStoreOrderHistory(){
            string str = "";
            return str;
        }
        
        
        
    }
}