using AppStore.DAL;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace AppStore
{
    public class OrderHistoryUI
    {
        public string GetGeneralOrderHistory(int customerId){
            string str = "";
            using(var db = new AppStoreContext()){
                var orders = db.OrderHistories
                    .Where(b => b.CustomerId == customerId)
                    .AsNoTracking()
                    .ToList();
                foreach(var order in orders){
                    str = str + order.ProductName + "\t\t   " + order.Quantity + "\t\t  " 
                    + order.Price + order.StoreId + "        "  + order.StoreId + "\n";
                }

            }
            if(str.Length == 0){ str = "No Record";}
            
            return str;
        }
        public string GetSpecificStoreOrderHistory(int customerId, int storeId){
            string str = "";
            using(var db = new AppStoreContext()){
                var orders = db.OrderHistories
                    .Where(b => b.CustomerId == customerId && b.StoreId == storeId)
                    .AsNoTracking()
                    .ToList();
                foreach(var order in orders){
                    str = str + order.ProductName + "\t\t   " + order.Quantity + "\t\t  " + order.Price + order.StoreId
                     + "        "  + order.StoreId + "\n";
               
                }
            }
            if(str.Length == 0){ str = "No Record";}


            return str;
        }
    }
}