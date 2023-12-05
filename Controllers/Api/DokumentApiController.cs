using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projekt.Data;
using projekt.Models;

namespace Projekt.Controllers_Api
{
    [Route("api/v1/dokument")]
    [ApiController]
    public class DokumentApiController : ControllerBase
    {
        private readonly kontekst _context;

        public DokumentApiController(kontekst context)
        {
            _context = context;
        }

        // GET: api/DokumentApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dokument>>> GetDokumenti()
        {
          if (_context.Dokumenti == null)
          {
              return NotFound();
          }
            return await _context.Dokumenti.ToListAsync();
        }

        // GET: api/DokumentApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dokument>> GetDokument(int? id)
        {
          if (_context.Dokumenti == null)
          {
              return NotFound();
          }
            var dokument = await _context.Dokumenti.FindAsync(id);

            if (dokument == null)
            {
                return NotFound();
            }

            return dokument;
        }

        // PUT: api/DokumentApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDokument(int? id, Dokument dokument)
        {
            if (id != dokument.DokumentID)
            {
                return BadRequest();
            }

            _context.Entry(dokument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DokumentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DokumentApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dokument>> PostDokument(Dokument dokument)
        {
          if (_context.Dokumenti == null)
          {
              return Problem("Entity set 'kontekst.Dokumenti'  is null.");
          }
            _context.Dokumenti.Add(dokument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDokument", new { id = dokument.DokumentID }, dokument);
        }

        // DELETE: api/DokumentApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDokument(int? id)
        {
            if (_context.Dokumenti == null)
            {
                return NotFound();
            }
            var dokument = await _context.Dokumenti.FindAsync(id);
            if (dokument == null)
            {
                return NotFound();
            }

            _context.Dokumenti.Remove(dokument);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DokumentExists(int? id)
        {
            return (_context.Dokumenti?.Any(e => e.DokumentID == id)).GetValueOrDefault();
        }
    }
}
