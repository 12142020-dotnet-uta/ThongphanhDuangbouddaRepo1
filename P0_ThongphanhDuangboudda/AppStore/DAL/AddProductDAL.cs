using System;
namespace AppStore.DAL
{
    public class AddProductDAL
    {
        public void AddProduct(Product product){
        //getStoreID //read store
            using(var db = new AppStoreContext()){
                var stores = db.Stores;
                /*
                foreach(var store in stores){
                    Console.WriteLine("StoreId: at add " + store.StoreId);
                    product.StoreId = store.StoreId;
                    db.Add(new Product{
                        ProductName = product.ProductName,
                        ProductDescription = product.ProductDescription,
                        Category = product.Category,
                        Price = product.Price,
                        StoreId = store.StoreId

                    });
                    
                 
                }
                */
                   product.ProductID = 1;
                    db.Add(product);
                    db.SaveChanges();

            }

        }
    }
}