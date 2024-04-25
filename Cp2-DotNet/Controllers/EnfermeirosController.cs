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
    public class EnfermeirosController : Controller
    {
        private readonly FIAPDbContext _context;

        public EnfermeirosController(FIAPDbContext context)
        {
            _context = context;
        }

        // GET: Enfermeiros
        public async Task<IActionResult> Index()
        {
            var fIAPDbContext = _context.Enfermeiros.Include(e => e.COREN);
            return View(await fIAPDbContext.ToListAsync());
        }

        // GET: Enfermeiros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Enfermeiros == null)
            {
                return NotFound();
            }

            var enfermeiro = await _context.Enfermeiros
                .Include(e => e.COREN)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enfermeiro == null)
            {
                return NotFound();
            }

            return View(enfermeiro);
        }

        // GET: Enfermeiros/Create
        public IActionResult Create()
        {
            ViewData["CORENId"] = new SelectList(_context.Set<COREN>(), "Id", "Numero");
            return View();
        }

        // POST: Enfermeiros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Setor,Telefone,CORENId")] Enfermeiro enfermeiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enfermeiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CORENId"] = new SelectList(_context.Set<COREN>(), "Id", "Numero", enfermeiro.CORENId);
            return View(enfermeiro);
        }

        // GET: Enfermeiros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Enfermeiros == null)
            {
                return NotFound();
            }

            var enfermeiro = await _context.Enfermeiros.FindAsync(id);
            if (enfermeiro == null)
            {
                return NotFound();
            }
            ViewData["CORENId"] = new SelectList(_context.Set<COREN>(), "Id", "Numero", enfermeiro.CORENId);
            return View(enfermeiro);
        }

        // POST: Enfermeiros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Setor,Telefone,CORENId")] Enfermeiro enfermeiro)
        {
            if (id != enfermeiro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enfermeiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnfermeiroExists(enfermeiro.Id))
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
            ViewData["CORENId"] = new SelectList(_context.Set<COREN>(), "Id", "Numero", enfermeiro.CORENId);
            return View(enfermeiro);
        }

        // GET: Enfermeiros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Enfermeiros == null)
            {
                return NotFound();
            }

            var enfermeiro = await _context.Enfermeiros
                .Include(e => e.COREN)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enfermeiro == null)
            {
                return NotFound();
            }

            return View(enfermeiro);
        }

        // POST: Enfermeiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enfermeiros == null)
            {
                return Problem("Entity set 'FIAPDbContext.Enfermeiros'  is null.");
            }
            var enfermeiro = await _context.Enfermeiros.FindAsync(id);
            if (enfermeiro != null)
            {
                _context.Enfermeiros.Remove(enfermeiro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnfermeiroExists(int id)
        {
          return (_context.Enfermeiros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
