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
        private readonly AppStoreContext _context;
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


    }
}
