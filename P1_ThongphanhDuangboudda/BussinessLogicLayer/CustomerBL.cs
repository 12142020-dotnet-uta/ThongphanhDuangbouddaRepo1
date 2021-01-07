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
    }
}
