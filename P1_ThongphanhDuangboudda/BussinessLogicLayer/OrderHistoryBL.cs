using System;
using System.Collections.Generic;
using System.Text;
using ModelLayer.Models;
using RepositoryLayer;

namespace BussinessLogicLayer
{
    public class OrderHistoryBL
    {
        private OrderHistoryRPTL _orderHistry;
        public OrderHistoryBL(OrderHistoryRPTL repo)
        {
            _orderHistry = repo;
        }

        /// <summary>
        /// This Method retun a list of product base on storeId
        /// </summary>
        /// <param name="customerId, storeId"></param>

        public List<OrderHistory> OrderHistoryByStore(int customerId, int storeId)
        {

            return (_orderHistry.OrderHistoryByStore(customerId, storeId));
        }
        /// <summary>
        /// This Method retun a list of OrderHistory base on storeId
        /// </summary>
        /// <param name="choice"></param>
        public List<OrderHistory> OderBy(int customerId, int choice)
        {
            return (_orderHistry.OderBy(customerId, choice));

        }
    }
}
