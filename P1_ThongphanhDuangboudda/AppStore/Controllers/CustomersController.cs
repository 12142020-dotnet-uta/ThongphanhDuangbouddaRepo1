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

namespace AppStore.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppStoreContext _context;
        private readonly CustomerBL _cusBL;

        public object Session { get; private set; }

        public CustomersController(AppStoreContext context, CustomerBL cus)
        {
            _context = context;
            _cusBL = cus;
        }
        //GET: Login
        public IActionResult Login()
        {
            return View();
        }
        //GET: CartDetail
        public async Task<IActionResult> CartDetail()
        {
            return View(await _context.Carts.ToListAsync());
        }

        // GET: Customers
        public IActionResult SignUP()
        {
            return View();
        }

        public async Task<IActionResult> Index(Customer cus = null)
        {
            return View(await _context.Customers.ToListAsync());
            /*
           var products =  await _context.Products.ToListAsync();
            return View(products);
            */
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
        //POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("CustomerId, FirstName, LastName")]Customer customer)
        {
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

            }
            
            Session = "Jim";
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult > SignUP([Bind("CustomerId,FirstName,LastName")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _cusBL.SignUP(customer);
                return RedirectToAction(nameof(Index));

            }
            /*
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            */
            return View(customer);
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
    }
}
