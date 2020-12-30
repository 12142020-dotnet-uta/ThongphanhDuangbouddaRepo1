using System;
using System.Collections.Generic;
using System.Linq;

namespace AppStore.DAL
{
    public class AddProductDAL
    {
        /*
        * PURPOSE : Add product to database
        *
        * RETURN : None
        *
        *F*/
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
        /*
        * PURPOSE : Get list of product by store ID
        *
        * RETURN : Available products
        *
        *F*/

        public List<Product> getListOfProducts(int storeID){
            List<Product> ps = new List<Product>();
            using(var db = new AppStoreContext()){
                var product = db.Products
                    .Where(x => x.StoreId == storeID).ToList();
                   ps = product; 
            }

            return ps;
        }
        /*
        * PURPOSE : Check product availability
        *
        * RETURN : True or false
        *
        *F*/
        public bool CheckProductAvailabilty(int storeID, int quantity){
            bool available = false;
            int availableQuantit = 0;
            using(var db = new AppStoreContext()){
                var product = db.Products
                    .Where(x =>x.StoreId == storeID)
                    .FirstOrDefault();
                    availableQuantit = product.Quantity;
                
                try{
                    if(product.Quantity -  quantity < 0){

                        throw new ArithmeticException("Access denied - You must enter fewer quantity");
                    }

                }
                catch(Exception e){ 
                    Console.WriteLine("Somthings wrong: " + e);
                }
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