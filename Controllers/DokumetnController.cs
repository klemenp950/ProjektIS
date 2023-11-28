using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projekt.Data;
using projekt.Models;

namespace Projekt.Controllers
{
    public class DokumetnController : Controller
    {
        private readonly kontekst _context;

        public DokumetnController(kontekst context)
        {
            _context = context;
        }

        // GET: Dokumetn
        public async Task<IActionResult> Index()
        {
            var kontekst = _context.Dokumenti.Include(d => d.Avtor).Include(d => d.Tip);
            return View(await kontekst.ToListAsync());
        }

        // GET: Dokumetn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dokumenti == null)
            {
                return NotFound();
            }

            var dokument = await _context.Dokumenti
                .Include(d => d.Avtor)
                .Include(d => d.Tip)
                .FirstOrDefaultAsync(m => m.DokumentID == id);
            if (dokument == null)
            {
                return NotFound();
            }

            return View(dokument);
        }

        // GET: Dokumetn/Create
        public IActionResult Create()
        {
            ViewData["AvtorID"] = new SelectList(_context.Avtorji, "AvtorID", "Ime");
            ViewData["TipID"] = new SelectList(_context.Tipi, "TipID", "Ime");
            return View();
        }

        // POST: Dokumetn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DokumentID,Ime,SteviloVrstic,SteviloZnakov,Velikost,Datum,TipID,AvtorID")] Dokument dokument)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dokument);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AvtorID"] = new SelectList(_context.Avtorji, "AvtorID", "AvtorID", dokument.AvtorID);
            ViewData["TipID"] = new SelectList(_context.Tipi, "TipID", "TipID", dokument.TipID);
            return View(dokument);
        }

        // GET: Dokumetn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dokumenti == null)
            {
                return NotFound();
            }

            var dokument = await _context.Dokumenti.FindAsync(id);
            if (dokument == null)
            {
                return NotFound();
            }
            ViewData["AvtorID"] = new SelectList(_context.Avtorji, "AvtorID", "Ime");
            ViewData["TipID"] = new SelectList(_context.Tipi, "TipID", "Ime");
            return View(dokument);
        }

        // POST: Dokumetn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("DokumentID,Ime,SteviloVrstic,SteviloZnakov,Velikost,Datum,TipID,AvtorID")] Dokument dokument)
        {
            if (id != dokument.DokumentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dokument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DokumentExists(dokument.DokumentID))
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
            ViewData["AvtorID"] = new SelectList(_context.Avtorji, "AvtorID", "AvtorID", dokument.AvtorID);
            ViewData["TipID"] = new SelectList(_context.Tipi, "TipID", "TipID", dokument.TipID);
            return View(dokument);
        }

        // GET: Dokumetn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dokumenti == null)
            {
                return NotFound();
            }

            var dokument = await _context.Dokumenti
                .Include(d => d.Avtor)
                .Include(d => d.Tip)
                .FirstOrDefaultAsync(m => m.DokumentID == id);
            if (dokument == null)
            {
                return NotFound();
            }

            return View(dokument);
        }

        // POST: Dokumetn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Dokumenti == null)
            {
                return Problem("Entity set 'kontekst.Dokumenti'  is null.");
            }
            var dokument = await _context.Dokumenti.FindAsync(id);
            if (dokument != null)
            {
                _context.Dokumenti.Remove(dokument);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DokumentExists(int? id)
        {
          return (_context.Dokumenti?.Any(e => e.DokumentID == id)).GetValueOrDefault();
        }
    }
}
