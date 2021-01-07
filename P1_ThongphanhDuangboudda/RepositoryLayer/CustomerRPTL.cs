using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<Customer> SignUP(Customer cus)
        {
            Customer customer = new Customer();
            customer.FirstName = cus.FirstName;
            customer.LastName = cus.LastName;


            _conText.Add(customer);
            await _conText.SaveChangesAsync();
            
            /*
          if (ModelState.IsValid)
          {
              _context.Add(customer);
              await _context.SaveChangesAsync();
              return RedirectToAction(nameof(Index));
          }
          */

            return cus;

        }

    }
}
