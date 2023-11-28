using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projekt.Data;
using projekt.Models;
using Microsoft.AspNetCore.Authorization;



namespace Projekt.Controllers
{
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class TipController : Controller
    {
        private readonly kontekst _context;

        public TipController(kontekst context)
        {
            _context = context;
        }

        // GET: Tip
        public async Task<IActionResult> Index()
        {
              return _context.Tipi != null ? 
                          View(await _context.Tipi.ToListAsync()) :
                          Problem("Entity set 'kontekst.Tipi'  is null.");
        }

        // GET: Tip/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tipi == null)
            {
                return NotFound();
            }

            var tip = await _context.Tipi
                .FirstOrDefaultAsync(m => m.TipID == id);
            if (tip == null)
            {
                return NotFound();
            }

            return View(tip);
        }

        // GET: Tip/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tip/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipID,Ime")] Tip tip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tip);
        }

        // GET: Tip/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tipi == null)
            {
                return NotFound();
            }

            var tip = await _context.Tipi.FindAsync(id);
            if (tip == null)
            {
                return NotFound();
            }
            return View(tip);
        }

        // POST: Tip/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipID,Ime")] Tip tip)
        {
            if (id != tip.TipID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipExists(tip.TipID))
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
            return View(tip);
        }

        // GET: Tip/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tipi == null)
            {
                return NotFound();
            }

            var tip = await _context.Tipi
                .FirstOrDefaultAsync(m => m.TipID == id);
            if (tip == null)
            {
                return NotFound();
            }

            return View(tip);
        }

        // POST: Tip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tipi == null)
            {
                return Problem("Entity set 'kontekst.Tipi'  is null.");
            }
            var tip = await _context.Tipi.FindAsync(id);
            if (tip != null)
            {
                _context.Tipi.Remove(tip);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipExists(int id)
        {
          return (_context.Tipi?.Any(e => e.TipID == id)).GetValueOrDefault();
        }
    }
}
