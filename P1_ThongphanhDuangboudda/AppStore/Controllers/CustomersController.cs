using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Models;
using RepositoryLayer;
using BussinessLogicLayer;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System.Web;

//using System.Web.Mvc;



namespace AppStore.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppStoreContext _context;
        private readonly CustomerBL _cusBL;
        protected ProductBL _productBL;

        // public object Session { get; private set; }
        public const string SessionKeyName = "_Name";
        public const string SessionKeyLast = "_Last";
        public const string  CustomerId = "_Id";
        const string SessionKeyTime = "_Time";
        

        public CustomersController(AppStoreContext context, CustomerBL cus, ProductBL product)
        {
            _context = context;
            _cusBL = cus;
            _productBL = product;
        }
        /// <summary>
        /// This Method retun login view
        /// </summary>
        /// <param name=""></param>
        public IActionResult Login(int? id) 
        {
            System.Diagnostics.Debug.WriteLine("not login customer is call + viewdata :  " + ViewData["err"]);
            if (id != null)
            {
                System.Diagnostics.Debug.WriteLine("not login customer is call");
                ViewData["er"] = "Please login first!!";
                return View();
            }
           // ViewData["er"] = "Please login first!!";
            return View();
        }
        /// <summary>
        /// This Method retun list of products in the  cart
        /// </summary>
        /// <param name=""></param>
        public async Task<IActionResult> CartDetail()
        {
            var customerId = HttpContext.Session.GetInt32(CustomerId);

            if (customerId == null)
            {
                ViewData["err"] = "Please Login";
                ViewData["er"] = "Please sign up!!";
                return RedirectToAction("Login", "Customers", new { id = 100 });
            }
            return View(await _context.Carts.Where(x =>x.CustomerId == (int)customerId).ToListAsync());
        }

        /// <summary>
        /// This Method retun sign up view
        /// </summary>
        /// <param name="storeId"></param>
        public IActionResult SignUP()
        {
            return View();
        }

        /// <summary>
        /// This Method retun view with list of product
        /// </summary>
        /// <param name="cus"></param>
        public async Task<IActionResult> Index(Customer cus = null)
        {
            return View(await _context.Customers.ToListAsync());
        
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// This Method check if a customer match on data base, then login if match.
        /// </summary>
        /// <param name="customer"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string button, [Bind("CustomerId, FirstName, LastName")]Customer customer)
        {
            System.Diagnostics.Debug.WriteLine("Button Vaule:=======> " + button);
            if (button == "Sign Up")
            {
                System.Diagnostics.Debug.WriteLine("SignUP");
               return RedirectToAction(nameof(SignUP));
            }
            Customer cus = new()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine(" log in Post called" + customer.FirstName + " and : " + customer.LastName  + "ID: " + customer.CustomerId);

                //check if the customer is exist in database
                cus = _cusBL.IsExistingCustomer(cus);
                if (cus == null)
                {
                    ViewData["er"] = "Please sign up!!";
                    return View();
                }
                else
                {
                    // Requires: using Microsoft.AspNetCore.Http;
                    HttpContext.Session.SetString(SessionKeyName, cus.FirstName);
                    HttpContext.Session.SetString(SessionKeyLast, cus.LastName);
                    HttpContext.Session.SetInt32(CustomerId, cus.CustomerId);
                    if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
                    {
                        HttpContext.Session.SetString(SessionKeyName, cus.FirstName);
                        HttpContext.Session.SetString(SessionKeyLast, cus.LastName);
                        HttpContext.Session.SetInt32(CustomerId, cus.CustomerId);
                
                    }

                    var name = HttpContext.Session.GetString(SessionKeyName);
                    var last = HttpContext.Session.GetString(SessionKeyLast);
                    var Id = HttpContext.Session.GetInt32(CustomerId);
                    //HttpContext.Session.Clear();
                    string fistName = name;
                    
                    System.Diagnostics.Debug.WriteLine("session===>     " + fistName);
                    System.Diagnostics.Debug.WriteLine("session===>     " + Id);
                    //ViewBag["FirstName"] = fistName;
                    ViewData.Add("FirstName", fistName);
                    ViewData["Id"] = Id;

                }

            }

            return RedirectToAction("Index", "Products");
        }
        /// <summary>
        /// This Method add customer to database and login customer in
        /// </summary>
        /// <param name="storeId"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult > SignUP([Bind("CustomerId,FirstName,LastName")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var name = HttpContext.Session.GetString(SessionKeyName);
                var last = HttpContext.Session.GetString(SessionKeyLast);
                var Id = HttpContext.Session.GetInt32(CustomerId);
                //HttpContext.Session.Clear();
                System.Diagnostics.Debug.WriteLine("session===>     " + name );
                ViewData["FisrtName"] = name;
                ViewData["Id"] = Id;
                //check if the customer is exist in database
                 customer = _cusBL.IsExistingCustomer(customer);
                if(customer != null)
                {

                }
                else
                {
                    //sign up customer
                    await _cusBL.SignUP(customer);
                }

                
                if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
                {
                    HttpContext.Session.SetString(SessionKeyName, customer.FirstName);
                    HttpContext.Session.SetString(SessionKeyLast, customer.LastName);
                    HttpContext.Session.SetInt32(CustomerId, customer.CustomerId);

                }
                return RedirectToAction("Index", "Products");          
            }
          
            return View(customer);
        }

        /// <summary>
        /// This Method add product to cart
        /// </summary>
        /// <param name="storeId"></param>
        public IActionResult AddOrder()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
        /// <summary>
        /// This Method retun a list of product base on storeId
        /// </summary>
        /// <param name="quantity"></param>
        public async Task<IActionResult> Add(int? id, int quantity)
        {
            int productId = (int)id;
            System.Diagnostics.Debug.WriteLine("Customer add is called Quantity is ===> " + quantity);
            var customerId = HttpContext.Session.GetInt32(CustomerId);
           
            if(customerId == null)
            {
                ViewData["err"] = "Please Login";
                ViewData["er"] = "Please sign up!!";
                return RedirectToAction("Login", "Customers", new { id = 100 });
            }
            //int cutomerId = (int)Id;
            
            bool available = true;
           available = _productBL.CheckProductAvailabilty((int)customerId, productId, quantity);
            if (!available)
            {

                System.Diagnostics.Debug.WriteLine("NOT Availble");
                ViewData["er"] = "Please enter fewer quantity!!";
                return RedirectToAction("Details", "Products", new { id = productId, quantity = 0, reEnter = true});
                // ViewData["er"] = "Excess inventory!!, enter fewer items";
                // return View();
            }

            if (id == null)
            {
                return NotFound();
            }


            var product = await _context.Products
                .Include(p => p.store)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            product.Quantity = quantity;
            return View(product);
        }
        /// <summary>
        /// This Method retun a list of product base on storeId
        /// </summary>
        /// <param name="storeId"></param>
        /// /
        /*
         *         public async Task<IActionResult> CartDetail()
        {
            var customerId = HttpContext.Session.GetInt32(CustomerId);

            if (customerId == null)
            {
                ViewData["err"] = "Please Login";
                ViewData["er"] = "Please sign up!!";
                return RedirectToAction("Login", "Customers", new { id = 100 });
            }
            return View(await _context.Carts.ToListAsync());
        }
         */
        public async Task<IActionResult> Checkout()
        {
            var customerId = HttpContext.Session.GetInt32(CustomerId);
            

            if (customerId == null)
            {
                ViewData["err"] = "Please Login";
                ViewData["er"] = "Please sign up!!";
                return RedirectToAction("Login", "Customers", new { id = 100 });
            }
            var items = await _context.Carts.Where(x => x.CustomerId == (int)customerId).ToListAsync();
            //add items to orderHistory
            foreach(var item in items)
            {  
                _context.Add(new OrderHistory
                {
                    CustomerId = (int)customerId,
                    ProductName = item.ProductName,
                    ProductDescription = item.ProductDescription,
                    Category = item.Category,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    StoreId = item.StoreId,
                    OrderDate = DateTime.Now

                });
                _context.Remove(item);

            }
           
            await _context.SaveChangesAsync();
           

           // _context.Carts.RemoveRange(_context.Carts);
           // _context.SaveChangesAsync();
            return View( await _context.OrderHistories.Where(x => x.CustomerId == (int)customerId).ToListAsync());
        }

        /// <summary>
        /// Log user out 
        /// </summary>
        /// <param name="n/a"></param>
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            //Session.Clear();
            return RedirectToAction("Index", "Products");
        }
    }
}
