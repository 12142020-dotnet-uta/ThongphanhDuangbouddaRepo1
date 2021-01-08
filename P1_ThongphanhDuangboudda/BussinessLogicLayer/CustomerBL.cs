using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Models;
using RepositoryLayer;

namespace BussinessLogicLayer
{
    public class CustomerBL
    {
        private readonly CustomerRPTL _cusRPTL;
        public CustomerBL(CustomerRPTL repositoryLayer)
        {
            _cusRPTL = repositoryLayer;

        }
        /// <summary>
        /// This Method retun and existing customer if found; otherwise return null
        /// </summary>
        /// <param name="cus"></param>
        public Customer IsExistingCustomer(Customer cus)
        {
            Customer customer = _cusRPTL.IsExistingCustomer(cus);
            if(customer != null)
            {
                return customer;
            }
            else
            {
                return null;
            }  
       
        }
        /// <summary>
        /// This Method retun a customer
        /// </summary>
        /// <param name="cus"></param>
        public async Task<Customer> SignUP(Customer cus)
        {
            Customer existing = _cusRPTL.IsExistingCustomer(cus);
            if (existing == null)
            {
                cus = await _cusRPTL.SignUP(cus);
                return cus;
            }
            else
            {
                return existing;
            }
            
        }
        /// <summary>
        /// This Method retun a list of product base on storeId
        /// </summary>
        /// <param name="storeId"></param>
        public void AddOrder(int customerId, int storeId, Product prduct)
        {

        }
    }
}
