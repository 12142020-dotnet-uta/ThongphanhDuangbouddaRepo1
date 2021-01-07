using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Models;
using RepositoryLayer;

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
        /// <summary>
        /// This Method retun a list of products with image Url
        /// </summary>
        /// <param name="products"></param>
        public static async Task<List<Product> >ConvertImageFile_SaveUrl(List<Product> products)
        {
            foreach(var product in products)
            {
                string imagDataBase64Daba = Convert.ToBase64String(product.ImageData);
                product.ImageString = string.Format("data:image/jpg; base64,{0}", imagDataBase64Daba);
            }
            return (products);

        }
    }
}
