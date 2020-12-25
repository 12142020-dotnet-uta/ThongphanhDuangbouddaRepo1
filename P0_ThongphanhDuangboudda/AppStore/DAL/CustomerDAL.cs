using System;
using System.Linq;
using System.Collections.Generic;
using AppStore.Models;

namespace AppStore.DAL
{
    public class CustomerDAL
    {
        public Customer IsExist(Customer customer){
            Customer cus = new Customer();
            using(var db = new AppStoreContext()){
                var found = db.Customers    
                .Where(x => x.FirstName == customer.FirstName && x.LastName == customer.LastName)
                .Single();

                db.SaveChanges();

                 if(found != null){
                     Console.WriteLine("Hellow  ===>:  " + found.FirstName + " ID " + found.CustomerId);
                    cus = found;
                }else{
                    Console.WriteLine("cant find ===> Customer ");
                }                     
            }
            return cus;
        }
    }
}