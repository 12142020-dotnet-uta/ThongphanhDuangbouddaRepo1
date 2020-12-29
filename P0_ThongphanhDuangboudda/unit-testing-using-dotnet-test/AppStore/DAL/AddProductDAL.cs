using System;
using System.Collections.Generic;
using System.Linq;

namespace AppStore.DAL
{
    public class AddProductDAL
    {
        public void AddProduct(Product product){
        //getStoreID //read store
            using(var db = new AppStoreContext()){
                var stores = db.Stores;
                 //product.StoreId = 1;
                // Console.WriteLine("prodcutName: " + product.ProductName);
                 foreach(var store in stores){
                     Product p = new Product();
                     p.ProductName = product.ProductName;
                     p.ProductDescription = product.ProductDescription;
                     p.Category = product.Category;
                     p.Price = product.Price;
                     p.Quantity = product.Quantity;
                     p.StoreId = store.StoreId;
                     db.Add(p);
                    
                }
                db.SaveChanges();
    
            }

        }

        public List<Product> getListOfProducts(int storeID){
            List<Product> ps = new List<Product>();
            using(var db = new AppStoreContext()){
                var product = db.Products
                    .Where(x => x.StoreId == storeID).ToList();
                   ps = product; 
            }

            return ps;
        }
        public bool CheckProductAvailabilty(int storeID, int quantity){
            bool available = false;
            int availableQuantit = 0;
            using(var db = new AppStoreContext()){
                var product = db.Products
                    .Where(x =>x.StoreId == storeID)
                    .FirstOrDefault();
                    availableQuantit = product.Quantity;
                if(product.Quantity -  quantity >= 0){

                    //TODO: In future update database product if customer add product to cart
                    //product.Quantity = product.Quantity - quantity;

                    available = true;
                } 
            }
            Console.WriteLine("enter quantity " + quantity + " available "  + availableQuantit);
            

            return available;

        }
        /*
        public void Checkout(List<Product> productList){
            using(var db = new AppStoreContext()){
                foreach(var product in productList){
                var dbProuct = db.Products
                .Where(x =>x.ProductID == product.ProductID)
                .FirstOrDefault();
                dbProuct.Quantity = dbProuct.Quantity - product.Quantity;
                }
    
            }

        }
        */
    }
}