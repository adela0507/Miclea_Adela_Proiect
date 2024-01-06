using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Miclea_Adela_Proiect.Data;
using Miclea_Adela_Proiect.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Miclea_Adela_Proiect.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = searchString;
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var products = from b in _context.Products
                        select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    products = products.OrderByDescending(b => b.Name);
                    break;
                case "Price":
                    products = products.OrderBy(b => b.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(b => b.Price);
                    break;
                default:
                    products = products.OrderBy(b => b.Name);
                    break;
            }
            return View(await products.AsNoTracking().ToListAsync());

        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p=>p.Producer)
                .Include(s => s.Orders)
                .ThenInclude(e => e.Customer)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["ProducerID"] = new SelectList(_context.Producers, "ProducerID", "ProducerName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Producer,Price")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (DbUpdateException /* ex*/)
            {

                ModelState.AddModelError("", "Unable to save changes. " + "Try again, and if the problem persists ");
            }

            ViewData["ProducerID"] = new SelectList(_context.Producers, "ProducerID", "ProducerName", product.ProducerID);
        
                return View(product);
            
         }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProducerName"] = new SelectList(_context.Producers, "ProducerName", "ProducerName", product.ProducerID);

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productToUpdate = await _context.Products.FirstOrDefaultAsync(s => s.ID == id);
            if (await TryUpdateModelAsync<Product>(productToUpdate, "", s => s.ProducerID, s => s.Name, s => s.Price))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists");
                }
            }

            return View(productToUpdate);
        }

            // GET: Products/Delete/5
            public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null )
            {
                return NotFound();
            }

            var product = await _context.Products
                 .Include(b => b.Producer)
                 .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed. Try again";
            }


            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {

                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
