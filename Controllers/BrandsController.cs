using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Miclea_Adela_Proiect.Data;
using Miclea_Adela_Proiect.Models;
using Miclea_Adela_Proiect.ProductViewModels;
using Miclea_Adela_Proiect.Models.ProductViewModels;

namespace Miclea_Adela_Proiect.Controllers
{
    public class BrandsController : Controller
    {
        private readonly ProductContext _context;

        public BrandsController(ProductContext context)
        {
            _context = context;
        }

        // GET: Brands
        /* public async Task<IActionResult> Index()
         {
               return _context.Brands != null ? 
                           View(await _context.Brands.ToListAsync()) :
                           Problem("Entity set 'ProductContext.Brands'  is null.");
         }
        */
        public async Task<IActionResult> Index(int? id, int? productID)
        {
            var viewModel = new BrandIndexData();
            viewModel.Brands = await _context.Brands
            .Include(i => i.BrandProducers)
            .ThenInclude(i => i.Product)
            .ThenInclude(i => i.Orders)
            .ThenInclude(i => i.Customer)
            .AsNoTracking()
            .OrderBy(i => i.BrandName)
            .ToListAsync();
            if (id != null)
            {
                ViewData["BrandID"] = id.Value;
                Brand brand = viewModel.Brands.Where(
                i => i.ID == id.Value).Single();
                viewModel.Products = brand.BrandProducers.Select(s => s.Product);
            }
            if (productID != null)
            {
                ViewData["ProductID"] = productID.Value;
                viewModel.Orders = viewModel.Products.Where(
                x => x.ID == productID).Single().Orders;
            }
            return View(viewModel);
        }

        // GET: Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands
                .FirstOrDefaultAsync(m => m.ID == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BrandName,Adress")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BrandName,Adress")] Brand brand)
        {
            if (id != brand.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(brand.ID))
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
            return View(brand);
        }

        // GET: Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands
                .FirstOrDefaultAsync(m => m.ID == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Brands == null)
            {
                return Problem("Entity set 'ProductContext.Brands'  is null.");
            }
            var brand = await _context.Brands.FindAsync(id);
            if (brand != null)
            {
                _context.Brands.Remove(brand);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandExists(int id)
        {
          return (_context.Brands?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
