using System;
using System.Linq;
using System.Collections.Generic;
using AppStore.Models;

namespace AppStore.DAL
{
    //update, delete, save, and provides data
    public class RepositoryLayer
    {

        public void AddStore(Store store){
            using(var db = new AppStoreContext()){
                db.Add(store);
                db.SaveChanges();
   

            }


        }  
        public List<Store>  GetStores(){
            lis<Store> stores; 
            using(var db = new AppStoreContext()){
                stores = db
            }
        }
        
    }
}