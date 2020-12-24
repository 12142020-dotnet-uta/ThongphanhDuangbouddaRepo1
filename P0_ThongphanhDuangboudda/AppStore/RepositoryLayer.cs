using System;
using System.Linq;
namespace AppStore
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
        
        
    }
}