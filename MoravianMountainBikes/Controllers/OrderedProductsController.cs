using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoravianMountainBikes.Models;

namespace MoravianMountainBikes.Controllers
{
    public class OrderedProductsController : Controller
    {
        private readonly MoravianContext _context;

        public OrderedProductsController(MoravianContext context)
        {
            _context = context;
        }

        // GET: OrderedProducts
        public async Task<IActionResult> Index()
        {
            var moravianContext = _context.OrderedProduct.Include(o => o.CustomerOrder);
            return View(await moravianContext.ToListAsync());
        }

        // GET: OrderedProducts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderedProduct = await _context.OrderedProduct
                .Include(o => o.CustomerOrder)
                .FirstOrDefaultAsync(m => m.CustomerOrderId == id);
            if (orderedProduct == null)
            {
                return NotFound();
            }

            return View(orderedProduct);
        }

        // GET: OrderedProducts/Create
        public IActionResult Create()
        {
            ViewData["CustomerOrderId"] = new SelectList(_context.CustomerOrder, "Id", "Id");
            return View();
        }

        // POST: OrderedProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerOrderId,ProductCode,Quantity")] OrderedProduct orderedProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderedProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerOrderId"] = new SelectList(_context.CustomerOrder, "Id", "Id", orderedProduct.CustomerOrderId);
            return View(orderedProduct);
        }

        // GET: OrderedProducts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderedProduct = await _context.OrderedProduct.FindAsync(id);
            if (orderedProduct == null)
            {
                return NotFound();
            }
            ViewData["CustomerOrderId"] = new SelectList(_context.CustomerOrder, "Id", "Id", orderedProduct.CustomerOrderId);
            return View(orderedProduct);
        }

        // POST: OrderedProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("CustomerOrderId,ProductCode,Quantity")] OrderedProduct orderedProduct)
        {
            if (id != orderedProduct.CustomerOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderedProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderedProductExists(orderedProduct.CustomerOrderId))
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
            ViewData["CustomerOrderId"] = new SelectList(_context.CustomerOrder, "Id", "Id", orderedProduct.CustomerOrderId);
            return View(orderedProduct);
        }

        // GET: OrderedProducts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderedProduct = await _context.OrderedProduct
                .Include(o => o.CustomerOrder)
                .FirstOrDefaultAsync(m => m.CustomerOrderId == id);
            if (orderedProduct == null)
            {
                return NotFound();
            }

            return View(orderedProduct);
        }

        // POST: OrderedProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var orderedProduct = await _context.OrderedProduct.FindAsync(id);
            _context.OrderedProduct.Remove(orderedProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderedProductExists(long id)
        {
            return _context.OrderedProduct.Any(e => e.CustomerOrderId == id);
        }
    }
}
