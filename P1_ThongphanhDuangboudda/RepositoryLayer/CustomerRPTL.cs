using System;
using System.Collections.Generic;
using System.Text;
using ModelLayer.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
   

    public class CustomerRPTL
    {
        private readonly AppStoreContext _conText;
        public CustomerRPTL(AppStoreContext appContext)
        {
            _conText = appContext;

        }
        public void AddCustomer(Customer customer)
        {

        }
        public Customer GetCustomer(Customer cus)
        {
            Customer customer = new Customer();

            return customer;
        }
        public Customer IsExistingCustomer(Customer cus)
        {
            var customer = _conText.Customers
                        .Where(x => x.FirstName == cus.FirstName && x.LastName == cus.LastName)
                        .AsNoTracking()
                        .FirstOrDefault();

            return customer;         
              
        }

    }
}
