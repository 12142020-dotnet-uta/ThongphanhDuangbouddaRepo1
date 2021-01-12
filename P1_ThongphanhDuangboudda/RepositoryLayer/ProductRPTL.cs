using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Models;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class ProductRPTL
    {
        protected  AppStoreContext _context;
        public ProductRPTL(AppStoreContext context)
        {
            _context = context;

        }
        /// <summary>
        /// This Method retun a list of product base on storeId
        /// </summary>
        /// <param name="storeId"></param>
        public async Task<List<Product>> GetProducts(int storeId = 0)
        {
            if(storeId > 0)
            {
               
                var products = _context.Products.Include(p => p.store.StoreId == storeId);
                return (await products.ToListAsync());
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("calles with store id: " + storeId);
                var products = _context.Products.Include(p => p.store);
                return (await products.ToListAsync());
            }
           

        }
        /// <summary>
        /// This Method retun a list of product base on storeId
        /// </summary>
        /// <param name="storeId"></param>
        public List<Product> GetProductsSync(int storeId = 0)
        {
           
            var products = _context.Products.Include(p => p.store);
            return (products.ToList());

        }
        /// <summary>
        /// This Method retun a list of product base on storeId
        /// </summary>
        /// <param name="storeId"></param>
        public List<Product> GetProductsSyncByStoreId(int storeId)
        {
            System.Diagnostics.Debug.WriteLine("calles with store id: " + storeId);
            var products = _context.Products.Where(p => p.StoreId == storeId);
            return (products.ToList());

        }
        /// <summary>
        /// This Method retun a list of product base on storeId
        /// </summary>
        /// <param name="storeId"></param>
        public Product GetProductById(int productId)
        {
            var product = _context.Products
                           .Where(x => x.ProductID == productId)
                           .AsNoTracking()
                           .FirstOrDefault();

            return product;
        }
        /// <summary>
        /// This Method retun a list of product base on storeId
        /// </summary>
        /// <param name="storeId"></param>
        public void AddToCart(int customerId, int productId, int quantity)
        {
            var product = _context.Products
                        .Where(x => x.ProductID == productId)
                        .FirstOrDefault();
            product.Quantity =  product.Quantity - quantity;
            int storeId = product.StoreId;
               


            Cart cart = new Cart();
            cart.ProductID = productId;
            cart.StoreId = storeId;
            cart.Price = product.Price;
            cart.Quantity = quantity;
            cart.CustomerId = customerId;
            cart.ProductName = product.ProductName;
            cart.ProductDescription = product.ProductDescription;
            cart.Category = product.Category;

            _context.Add(cart);
            _context.SaveChanges();
        }

        /// <summary>
        /// This Method retun a list of product base on storeId
        /// </summary>
        /// <param name="customerId"></param>
        /// 
         /*
        * PURPOSE : Get order suggestion for customer
        *
        * RETURN : String of product information
        *
        *F*/
        public List<Product> GetOrderSuggestions(int customerId)
        {
            var rand = new Random();
            string str = "";
            int electronic = 0;
            int grocery = 0;
            int clothing = 0;
            List<Product> listOfProducts;
           
            //min inclued, max exclude
            int number = rand.Next(0, 5);
            using (var db = new AppStoreContext())
            {
                var orderHis = db.OrderHistories
                    .Where(x => x.CustomerId == customerId)
                    .AsNoTracking()
                    .ToList();
                foreach (var order in orderHis)
                {
                    if (order.Category == "Electronic")
                    {
                        electronic++;
                    }
                    else if (order.Category == "Clothing")
                    {
                        clothing++;
                    }
                    else if (order.Category == "Grocery")
                    {
                        grocery++;
                    }
                }

                if (electronic > grocery)
                {
                    listOfProducts = db.Products
                                .Where(p => p.Category == "Electronic")
                                .AsNoTracking().ToList();

                    return listOfProducts;
                   
                }
                else if (clothing > grocery)
                {
                    listOfProducts = db.Products
                                .Where(p => p.Category == "Clothing")
                                .AsNoTracking().ToList();
                                
                }
                else
                {
                    listOfProducts = db.Products
                                .Where(p => p.Category == "Grocery")
                                .AsNoTracking().ToList();
                               
                    return listOfProducts;

                }
                

            }
            return listOfProducts;

        }

    }
}
