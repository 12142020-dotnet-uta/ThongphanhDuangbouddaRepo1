using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ModelLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
   public class OrderHistoryRPTL
    {
        protected AppStoreContext _context;
        public OrderHistoryRPTL(AppStoreContext context)
        {
            _context = context;

        }
        /// <summary>
        /// This Method retun a list of product base on storeId
        /// </summary>
        /// <param name="customerId, storeId"></param>
        public  List<OrderHistory> OrderHistoryByStore(int cutomerId, int storeId)
        {
            var appStoreContext0 = _context.OrderHistories.Where(x => x.CustomerId == cutomerId && x.StoreId == storeId);
           // ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
            return ( appStoreContext0.ToList());
        }
        /// <summary>
        /// This Method retun a list of OrderHistory base on storeId
        /// </summary>
        /// <param name="choice"></param>
        public List<OrderHistory> OderBy(int customerId, int choice)
        {
            // (+5: order history can be sorted by earliest, latest, cheapest, most expensive, etc)
            //int slected = choice
            switch (choice)
            {
                case 1:
                    //Earliest
                    return( _context.OrderHistories.Where(x => x.CustomerId == customerId).OrderBy(x => x.OrderDate).ToList());
    
                case 2:
                    // Latest
                    return (_context.OrderHistories.Where(x => x.CustomerId == customerId).OrderByDescending(x => x.OrderDate).ToList());
                    
                case 3:
                    //Cheapest
                    return (_context.OrderHistories.Where(x => x.CustomerId == customerId).OrderBy(x => x.Price).ToList());
                case 4:
                    //Most expensive
                    return (_context.OrderHistories.Where(x => x.CustomerId == customerId).OrderByDescending(x => x.Price).ToList());

            }

           return _context.OrderHistories.ToList();
        }
    }
}
