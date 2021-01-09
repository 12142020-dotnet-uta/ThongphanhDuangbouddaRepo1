using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Models;
using RepositoryLayer;

namespace AppStore.Controllers
{
    public class OrderHistoriesController : Controller
    {
        private readonly AppStoreContext _context;

        public OrderHistoriesController(AppStoreContext context)
        {
            _context = context;
        }

        // GET: OrderHistories
        public async Task<IActionResult> Index()
        {
            var appStoreContext = _context.OrderHistories.Include(o => o.customer).Include(o => o.store);
            return View(await appStoreContext.ToListAsync());
        }

        // GET: OrderHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderHistory = await _context.OrderHistories
                .Include(o => o.customer)
                .Include(o => o.store)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderHistory == null)
            {
                return NotFound();
            }

            return View(orderHistory);
        }

        // GET: OrderHistories/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FirstName");
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
            return View();
        }

        // POST: OrderHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,ProductName,ProductDescription,Category,Price,Quantity,OrderDate,StoreId")] OrderHistory orderHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FirstName", orderHistory.CustomerId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", orderHistory.StoreId);
            return View(orderHistory);
        }

        // GET: OrderHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderHistory = await _context.OrderHistories.FindAsync(id);
            if (orderHistory == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FirstName", orderHistory.CustomerId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", orderHistory.StoreId);
            return View(orderHistory);
        }

        // POST: OrderHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId,ProductName,ProductDescription,Category,Price,Quantity,OrderDate,StoreId")] OrderHistory orderHistory)
        {
            if (id != orderHistory.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderHistoryExists(orderHistory.OrderId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FirstName", orderHistory.CustomerId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", orderHistory.StoreId);
            return View(orderHistory);
        }

        // GET: OrderHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderHistory = await _context.OrderHistories
                .Include(o => o.customer)
                .Include(o => o.store)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderHistory == null)
            {
                return NotFound();
            }

            return View(orderHistory);
        }

        // POST: OrderHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderHistory = await _context.OrderHistories.FindAsync(id);
            _context.OrderHistories.Remove(orderHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderHistoryExists(int id)
        {
            return _context.OrderHistories.Any(e => e.OrderId == id);
        }
    }
}
