using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cp2_DotNet.Models;
using Cp2_DotNet.Persistencia;

namespace Cp2_DotNet.Controllers
{
    public class PediatrasController : Controller
    {
        private readonly FIAPDbContext _context;

        public PediatrasController(FIAPDbContext context)
        {
            _context = context;
        }

        // GET: Pediatras
        public async Task<IActionResult> Index()
        {
            var fIAPDbContext = _context.Pediatras.Include(p => p.CRM);
            return View(await fIAPDbContext.ToListAsync());
        }

        // GET: Pediatras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pediatras == null)
            {
                return NotFound();
            }

            var pediatra = await _context.Pediatras
                .Include(p => p.CRM)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pediatra == null)
            {
                return NotFound();
            }

            return View(pediatra);
        }

        // GET: Pediatras/Create
        public IActionResult Create()
        {
            ViewData["CRMId"] = new SelectList(_context.Set<CRM>(), "CRMId", "Numero");
            return View();
        }

        // POST: Pediatras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Telefone,Email,CRMId")] Pediatra pediatra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pediatra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CRMId"] = new SelectList(_context.Set<CRM>(), "CRMId", "Numero", pediatra.CRMId);
            return View(pediatra);
        }

        // GET: Pediatras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pediatras == null)
            {
                return NotFound();
            }

            var pediatra = await _context.Pediatras.FindAsync(id);
            if (pediatra == null)
            {
                return NotFound();
            }
            ViewData["CRMId"] = new SelectList(_context.Set<CRM>(), "CRMId", "Numero", pediatra.CRMId);
            return View(pediatra);
        }

        // POST: Pediatras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Telefone,Email,CRMId")] Pediatra pediatra)
        {
            if (id != pediatra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pediatra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PediatraExists(pediatra.Id))
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
            ViewData["CRMId"] = new SelectList(_context.Set<CRM>(), "CRMId", "Numero", pediatra.CRMId);
            return View(pediatra);
        }

        // GET: Pediatras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pediatras == null)
            {
                return NotFound();
            }

            var pediatra = await _context.Pediatras
                .Include(p => p.CRM)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pediatra == null)
            {
                return NotFound();
            }

            return View(pediatra);
        }

        // POST: Pediatras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pediatras == null)
            {
                return Problem("Entity set 'FIAPDbContext.Pediatras'  is null.");
            }
            var pediatra = await _context.Pediatras.FindAsync(id);
            if (pediatra != null)
            {
                _context.Pediatras.Remove(pediatra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PediatraExists(int id)
        {
          return (_context.Pediatras?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
