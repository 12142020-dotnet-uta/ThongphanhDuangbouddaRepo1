using System;
using System.Collections.Generic;
using System.Text;
using ModelLayer.Models;

namespace BussinessLogicLayer
{
    public interface ICustomer
    {
        public Customer SignUp(Customer cus) { return cus; }
        //login
        public Customer Login(Customer cus) { return cus; }
        //add order cart
        public void AddOrder(int customerId, int storeId, Product products) { }
       
        //Checkou out items
       // public void Checkout(int customerId,int storeId, Product prords) { }
        //View general order history
       // public OrderHistory ViewGeneralOrderHistory(int customerId) { return new OrderHistory(); }
        // View Orderhistory By store
      //  public OrderHistory ViewOrderHistoryByStore(int customerId, int storeId) { return new OrderHistory(); }
        //View OrderHistory By Most expensive
       // // View Order History by Less Expensive
       // public OrderHistory ViewOrderHistoryByLessExpensive(int customerId) { return new OrderHistory(); }
        //View Order History by Less expensive
      //  public OrderHistory ViewOrderHistoryByLatest(int customerId) { return new OrderHistory(); }
        // View order history by ealiest
      //  public OrderHistory ViewOrderHistoryByEaliest(int customerId) { return new OrderHistory(); }



    }
}
