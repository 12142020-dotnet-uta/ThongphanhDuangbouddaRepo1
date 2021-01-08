using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Models;
using RepositoryLayer;
using Microsoft.AspNetCore.Http;
using System.IO;
using BussinessLogicLayer;
using System.ComponentModel.DataAnnotations;

namespace AppStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppStoreContext _context;
        private readonly ProductBL _productBL;

        public ProductsController(AppStoreContext context, ProductBL productBL)
        {
            _context = context;
            _productBL = productBL;
        }

        // GET: Products
        [HttpPost]
        public async Task<IActionResult> IndexSelectStore(int? id)
        {


           // var selectedValue = Request.Form["storeId"].ToString(); //this will get selected
            System.Diagnostics.Debug.WriteLine("Store Id =========>Called " );
            /*
            if (storId > 0)
            {
                System.Diagnostics.Debug.WriteLine("Store Id =========> " + storId);
            }
            */
            ViewData["StoreId"] = new SelectList( _context.Stores, "StoreId", "StoreId");

            return View( _productBL.GetProductsSync(1));
        }
        public async Task<IActionResult> Index(int storId)
        {
            System.Diagnostics.Debug.WriteLine("Store Id ========= bbbb> " + ViewData["storeId"]);
            System.Diagnostics.Debug.WriteLine("Store Id Xxxxxx ========= bbbb> " + storId);

            //var selectedValue = Request.Form["storeId"].ToString(); //this will get selected
            //System.Diagnostics.Debug.WriteLine("Store Id =========> " + selectedValue);
            if (storId > 0)
            {
                System.Diagnostics.Debug.WriteLine("Store Id i=optional =========> " + storId);
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
            return View(_productBL.GetProductsSync(1));
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id, int aId)
        {
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

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,ProductDescription,Category,Price,Quantity,StoreId,ImageData")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", product.StoreId);
            return View(product);
        }
        //store
        public async Task<IActionResult> Store1(int? id)
        {
            System.Diagnostics.Debug.WriteLine("got store id :   " + id);
     
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", product.StoreId);
            return View(product);
        }


        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", product.StoreId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,ProductDescription,Category,Price,Quantity,StoreId,ImageData")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    foreach(var file in Request.Form.Files)
                    {
                        MemoryStream ms = new MemoryStream();
                        file.CopyTo(ms);
                        product.ImageData = ms.ToArray();
                        ms.Close();
                        ms.Dispose();
                    }

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", product.StoreId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            System.Diagnostics.Debug.WriteLine("delete id is : " + id);
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

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
        // GET: Products/Details/5
        public async Task<IActionResult> Checout(int? id, int aId)
        {
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

            return View(product);
        }
        public async Task<IActionResult> Add(int? id, int aId)
        {
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

            return View(product);
        }

    }
}
