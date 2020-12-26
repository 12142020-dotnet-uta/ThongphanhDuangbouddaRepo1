using System;
namespace AppStore.DAL
{
    public class AddProductDAL
    {
        public void AddProduct(Product product){
        //getStoreID //read store
            using(var db = new AppStoreContext()){
                var stores = db.Stores;
                 //product.StoreId = 1;
                 Console.WriteLine("prodcutName: " + product.ProductName);
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
    }
}