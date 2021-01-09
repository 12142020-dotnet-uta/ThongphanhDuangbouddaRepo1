using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Models;
using RepositoryLayer;
using System.Linq;

namespace BussinessLogicLayer
{
    public class ProductBL
    {
        private readonly ProductRPTL _productRepo;
        public ProductBL(ProductRPTL repo)
        {
            _productRepo = repo;

        }
        /// <summary>
        /// This Method retun a list of product base on storeId
        /// </summary>
        /// <param name="storeId"></param>
        public async Task<List<Product>> GetProducts(int storeId = 0)
        {
            List<Product> products = await _productRepo.GetProducts(storeId);
            
            //var tasks = new List<Task> { List<Product> };
           // Task finish = await Task.Run();
            
            products =  await ConvertImageFile_SaveUrl(products);
            return products;
           // return (await _productRepo.GetProducts(storeId));

        }
        public List<Product> GetProductsSync(int storeId = 0)
        {
            List<Product> products =  _productRepo.GetProductsSync(storeId);

            //var tasks = new List<Task> { List<Product> };
            // Task finish = await Task.Run();

            products = ConvertImageFile_SaveUrlSync(products);
            return products;
            // return (await _productRepo.GetProducts(storeId));

        }
        public List<Product> GetProductsSyncByStoreId(int storeId)
        {
            List<Product> products = _productRepo.GetProductsSyncByStoreId(storeId);

            //var tasks = new List<Task> { List<Product> };
            // Task finish = await Task.Run();

            products = ConvertImageFile_SaveUrlSync(products);
            return products;
            // return (await _productRepo.GetProducts(storeId));

        }
        /// <summary>
        /// This Method retun a list of products with image Url
        /// </summary>
        /// <param name="products"></param>
        public static List<Product> ConvertImageFile_SaveUrlSync(List<Product> products)
        {
            foreach (var product in products)
            {
                if(product.ImageData != null)
                {
                    string imagDataBase64Daba = Convert.ToBase64String(product.ImageData);
                    product.ImageString = string.Format("data:image/jpg; base64,{0}", imagDataBase64Daba);

                }
               
            }
            return (products);
        }
        /// <summary>
        /// This Method retun a list of products with image Url
        /// </summary>
        /// <param name="products"></param>
        public static async Task<List<Product> >ConvertImageFile_SaveUrl(List<Product> products)
        {
            foreach(var product in products)
            {
                System.Diagnostics.Debug.WriteLine("size image data" + product.ImageData.Length);

                if(product.ImageData != null)
                {
                    string imagDataBase64Daba = Convert.ToBase64String(product.ImageData);
                    product.ImageString = string.Format("data:image/jpg; base64,{0}", imagDataBase64Daba);
                }
                
            }
            return (products);
        }

        /*
* PURPOSE : Check product availability
*
* RETURN : True or false
*
*F*/
        public bool CheckProductAvailabilty(int productId, int quantity)
        {
            bool available = false;
            int availableQuantit = 0;
            using (var db = new AppStoreContext())
            {
                var product = _productRepo.GetProductById(productId);
                availableQuantit = product.Quantity;

                try
                {
                    if (product.Quantity - quantity < 0)
                    {

                        throw new ArithmeticException("Access denied - You must enter fewer quantity");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Somthings wrong: " + e);
                }
                if (product.Quantity - quantity >= 0)
                {

                    //TODO: In future update database product if customer add product to cart
                    //product.Quantity = product.Quantity - quantity;
                    available = true;
                }
            }
            Console.WriteLine("enter quantity " + quantity + " available " + availableQuantit);

            //add product to cart 
            _productRepo.AddToCart(productId, quantity);
            return available;

        }
        

        //add order cart
        public void AddOrder(int customerId, int storeId, Product products)
        {


        }
    }
}
