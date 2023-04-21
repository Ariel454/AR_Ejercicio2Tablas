using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AR_Ejercicio2Tablas.Data;
using AR_Ejercicio2Tablas.Models;

namespace AR_Ejercicio2Tablas.Controllers
{
    public class BurguersController : Controller
    {
        private readonly AR_DBContext _context;

        public BurguersController(AR_DBContext context)
        {
            _context = context;
        }

        // GET: Burguers
        public async Task<IActionResult> Index()
        {
              return _context.Burguer != null ? 
                          View(await _context.Burguer.ToListAsync()) :
                          Problem("Entity set 'AR_Ejercicio2TablasContext.Burguer'  is null.");
        }

        // GET: Burguers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Burguer == null)
            {
                return NotFound();
            }

            var burguer = await _context.Burguer
                .FirstOrDefaultAsync(m => m.BurguerId == id);
            if (burguer == null)
            {
                return NotFound();
            }

            return View(burguer);
        }

        // GET: Burguers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Burguers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BurguerId,Name,WithCheese")] Burguer burguer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(burguer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(burguer);
        }

        // GET: Burguers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Burguer == null)
            {
                return NotFound();
            }

            var burguer = await _context.Burguer.FindAsync(id);
            if (burguer == null)
            {
                return NotFound();
            }
            return View(burguer);
        }

        // POST: Burguers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BurguerId,Name,WithCheese")] Burguer burguer)
        {
            if (id != burguer.BurguerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(burguer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BurguerExists(burguer.BurguerId))
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
            return View(burguer);
        }

        // GET: Burguers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Burguer == null)
            {
                return NotFound();
            }

            var burguer = await _context.Burguer
                .FirstOrDefaultAsync(m => m.BurguerId == id);
            if (burguer == null)
            {
                return NotFound();
            }

            return View(burguer);
        }

        // POST: Burguers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Burguer == null)
            {
                return Problem("Entity set 'AR_Ejercicio2TablasContext.Burguer'  is null.");
            }
            var burguer = await _context.Burguer.FindAsync(id);
            if (burguer != null)
            {
                _context.Burguer.Remove(burguer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BurguerExists(int id)
        {
          return (_context.Burguer?.Any(e => e.BurguerId == id)).GetValueOrDefault();
        }
    }
}
