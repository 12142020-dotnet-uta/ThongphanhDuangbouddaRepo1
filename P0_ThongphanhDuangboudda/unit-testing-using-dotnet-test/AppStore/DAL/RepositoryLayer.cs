using System;
using System.Linq;
using System.Collections.Generic;
using AppStore.Models;

namespace AppStore.DAL
{
    //update, delete, save, and provides data
    public class RepositoryLayer
    {
        /*
        * PURPOSE : Add store to database
        *
        * RETURN : None
        *
        *F*/
        public void AddStore(Store store){
            using(var db = new AppStoreContext()){
                db.Add(store);
                db.SaveChanges();
   

            }


        } 
        /*
        * PURPOSE : Add customer to database
        *
        * RETURN : None
        *
        *F*/
        public void AddCustomer(Customer customer) {
            using(var db = new AppStoreContext()){
                db.Add(customer);
                db.SaveChanges();
            }
        }
        /*
        public List<Store>  GetStores(){
            lis<Store> stores; 
            using(var db = new AppStoreContext()){
                //Todo
            }
        }
        */
    }
}