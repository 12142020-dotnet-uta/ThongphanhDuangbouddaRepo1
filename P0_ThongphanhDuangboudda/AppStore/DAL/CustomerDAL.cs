using System;
using System.Linq;
using System.Collections.Generic;
using AppStore.Models;

namespace AppStore.DAL
{
    public class CustomerDAL
    {
        
        public Customer IsExist(Customer customer){
            Customer cus = customer;
            using(var db = new AppStoreContext()){
                var found = db.Customers    
                .Where(x => x.FirstName == customer.FirstName && x.LastName == customer.LastName)
                .FirstOrDefault();

                db.SaveChanges();

                if(found != null){
                    // Console.WriteLine("Hellow  ===>:  " + found.FirstName + " ID " + found.CustomerId);
                    cus = found;
                }else{
                   // Console.WriteLine("cant find ===> Customer ");
                    return  null;
                }                     
            }
            return cus;
        }

        //Get product suggestion
        public string geProductSuggestion(Customer customer){
            string str ="";
            str = "Your should buy these items";

            return str;

        }
        //customer checkout //added to history
        public void Checkout(List<Product> checkoutList, int storeId, int customerId){
            using(var db = new AppStoreContext()){
                foreach(var product in checkoutList){
                    var dbProuct = db.Products
                        .Where(x =>x.ProductID == product.ProductID)
                        .FirstOrDefault();
                        dbProuct.Quantity = dbProuct.Quantity - product.Quantity;
                }
                db.SaveChanges();
            }   
        }
    }   
