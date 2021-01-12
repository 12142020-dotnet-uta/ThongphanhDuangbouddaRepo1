using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ModelLayer.Models;
using RepositoryLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
//Microsoft.IHttpContextAccessor HttpContextAccessor



namespace BussinessLogicLayer
{
    public class CustomerBL : ICustomer
    {
        private readonly CustomerRPTL _cusRPTL;
        // public object Session { get; private set; }
        public const string SessionKeyName = "_Name";
        public const string SessionKeyLast = "_Last";
        public const string CustomerId = "_Id";
        const string SessionKeyTime = "_Time";
        private IHttpContextAccessor _httpContextAccessor;
      
        public CustomerBL(CustomerRPTL repositoryLayer, IHttpContextAccessor httpContextAccessor)
        {
            _cusRPTL = repositoryLayer;
            _httpContextAccessor = httpContextAccessor;

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
        public async Task<Customer> SignUP(Customer customer)
        {
           // customer = await _cusRPTL.SignUP(customer);
            return await _cusRPTL.SignUP(customer);
            /*
            // Customer existing = _cusRPTL.IsExistingCustomer(customer);
            if (existing == null)
            {
              //  customer = await _cusRPTL.SignUP(customer);

                /*
                if (string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Session.GetString(SessionKeyName)))
                {
                    _httpContextAccessor.HttpContext.Session.SetString(SessionKeyName, customer.FirstName);
                    _httpContextAccessor.HttpContext.Session.SetString(SessionKeyLast, customer.LastName);
                    _httpContextAccessor.HttpContext.Session.SetInt32(CustomerId, customer.CustomerId);

                }*/
            /*
                return customer;
            }
            else
            {
                if (string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Session.GetString(SessionKeyName)))
                {
                    _httpContextAccessor.HttpContext.Session.SetString(SessionKeyName, customer.FirstName);
                    _httpContextAccessor.HttpContext.Session.SetString(SessionKeyLast, customer.LastName);
                    _httpContextAccessor.HttpContext.Session.SetInt32(CustomerId, customer.CustomerId);

                }
                return existing;
            }
            */
        }
        /// <summary>
        /// This Method retun a list of product base on storeId
        /// </summary>
        /// <param name="customerId, storeId, product"></param>
        public void AddOrder(int customerId, int storeId, Product prduct)
        {

        }
        /// <summary>
        /// This Method retun a list of product base on storeId
        /// </summary>
        /// <param name="cus"></param>
        public Customer Login(Customer cus)
        {
            return cus;
        }
        /// <summary>
        /// This Method set Session
        /// </summary>
        /// <param name="Customer object"></param>
        public void SetSession(Customer customer)
        {
            // Requires: using Microsoft.AspNetCore.Http;
            
            _httpContextAccessor.HttpContext.Session.SetString(SessionKeyName, customer.FirstName);
            _httpContextAccessor.HttpContext.Session.SetString(SessionKeyLast, customer.LastName);
            _httpContextAccessor.HttpContext.Session.SetInt32(CustomerId, customer.CustomerId);
            if (string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Session.GetString(SessionKeyName)))
            {
                _httpContextAccessor.HttpContext.Session.SetString(SessionKeyName, customer.FirstName);
                _httpContextAccessor.HttpContext.Session.SetString(SessionKeyLast, customer.LastName);
                _httpContextAccessor.HttpContext.Session.SetInt32(CustomerId, customer.CustomerId);

            }

        }
    }
}
