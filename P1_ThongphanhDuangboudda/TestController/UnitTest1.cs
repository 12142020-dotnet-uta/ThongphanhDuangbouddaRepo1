using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models;
using RepositoryLayer;
using BussinessLogicLayer;
using Microsoft.EntityFrameworkCore;
using AppStore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestController
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ILogger<HomeController> _logger;

        private UserController _userController = new UserController();
        
        private CustomersController _customersController;
        public CustomerBL _customerBL = new CustomerBL();
        private string lastName = "";
        private int customerId = 1;
       
        //test edit controller
        [TestMethod]
        public void TestEdit()
        {
            var controller = new UserController();
            var result = controller.Edit(1) as ViewResult;
            Assert.IsNotNull(result);

        }

      
        //test index action
        [TestMethod] 
        public void TestMethod1()
        {
            var controller = new UserController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
            result = controller.Login() as ViewResult;
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void TestLogIn()
        {
            var controller = new UserController();
            var retsult = controller.Login() as ViewResult;
            Assert.IsNotNull(retsult);
;
        }
        [TestMethod]
        public void TestDelet()
        {
            var result = _userController.Delete(1) as ViewResult;

            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void TestCreat()
        {
            var result = _userController.Create();
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void HomeControllerTestInex()
        {
            string firstName = "";
            using(var db = new AppStoreContext())
            {
                var customer = db.Customers.Where(x => x.FirstName == "Jim").FirstOrDefault();
                firstName = customer.FirstName;
                lastName = customer.LastName;
                customerId = customer.CustomerId;
            }
            Assert.AreEqual("Jim", firstName);
            Assert.AreEqual("Jim", firstName);
            Assert.AreEqual("Lake", lastName);


        }
        [TestMethod]
        public void TestIfReturnCorrectLastName()
        {
            using (var db = new AppStoreContext())
            {
                var customer = db.Customers.Where(x => x.FirstName == "Jim").FirstOrDefault();
                //firstName = customer.FirstName;
                lastName = customer.LastName;
                customerId = customer.CustomerId;
            }
            Assert.AreEqual("Lake", lastName);
        }
        [TestMethod]
        public void TestCustomerid()
        {
            Assert.AreNotEqual(5, customerId);
        }
        [TestMethod]
        public void TestProductRPL_GetProducts(ProductRPTL _productRPTL)
        {
          Task<List<Product>> lists =  _productRPTL.GetProducts(1);
            Assert.IsNotNull(lists);
        }
        [TestMethod]
        public void TestCustomerBL_Login()
        {
            Customer customer = new Customer
            {
                FirstName = "Bill",
                LastName = "j"
            };
            customer = _customerBL.Login(customer);
            Assert.IsNotNull(customer);
        }
        [TestMethod]
        public void TestIsExistingCusomer()
        {
          // var controller = HomeController();
           
            Customer customer = new Customer()
            {
                FirstName = "Jim",
                LastName = "Lake"
            };
            customer = _customerBL.IsExistingCustomer(customer);

            Assert.AreEqual("Jim", customer.FirstName);
        }

        /* 
         [TestMethod]

         public void CustomerBL_IsExtistingCustomerTest()
         {
             Customer customer = new()
             {
                 FirstName = "Thongphanh",
                 LastName = "Duangboudda",


             };
           customer =  _customerBL.IsExistingCustomer(customer);
             Assert.IsNull(customer);

         }*/



        /*
        public void CustomerControllerTest()
        {
            var result = _customersController.Login(1) as ViewResult;
            Assert.IsNotNull(result);
        }
       
        [TestMethod]
        public async void CustomerControllCartDetail()
        {
            var result = await _customersController.CartDetail() as ViewResult;
           // Assert.IsNotNull(await _customersController.CartDetail() as ViewResult);
        }*/
        [TestMethod]
        public void AboutIndexTest()
        {
            // Arrange
            var controller = new UserController();
            // Act
            var result = controller.Index();
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResult = result as ViewResult;

            Assert.AreNotEqual(typeof(UserController), viewResult);
        }

    }
}
