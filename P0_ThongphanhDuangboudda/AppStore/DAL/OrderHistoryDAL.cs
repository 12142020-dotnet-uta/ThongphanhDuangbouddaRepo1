using System.Collections.Generic;
using AppStore.Models;
using System;
namespace AppStore.DAL
{
    public class OrderHistoryDAL
    {
        public void RecordOrder(Product product, int storeID, int customerId){
            Console.WriteLine("at RecordOrder");
            using(var db = new AppStoreContext()){
                db.Add(new OrderHistory{
                    CustumerId = customerId,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    Category = product.Category,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    OrderDate = DateTime.Now

                });
            }
            
        
            
        }
        
    }
}