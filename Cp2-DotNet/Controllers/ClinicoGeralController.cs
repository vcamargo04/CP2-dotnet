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
    public class ClinicoGeralController : Controller
    {
        private readonly FIAPDbContext _context;

        public ClinicoGeralController(FIAPDbContext context)
        {
            _context = context;
        }

        // GET: ClinicoGeral
        public async Task<IActionResult> Index()
        {
            var fIAPDbContext = _context.ClinicoGerais.Include(c => c.CRM);
            return View(await fIAPDbContext.ToListAsync());
        }

        // GET: ClinicoGeral/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClinicoGerais == null)
            {
                return NotFound();
            }

            var clinicoGeral = await _context.ClinicoGerais
                .Include(c => c.CRM)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clinicoGeral == null)
            {
                return NotFound();
            }

            return View(clinicoGeral);
        }

        // GET: ClinicoGeral/Create
        public IActionResult Create()
        {
            ViewData["CRMId"] = new SelectList(_context.Set<CRM>(), "CRMId", "Numero");
            return View();
        }

        // POST: ClinicoGeral/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Especialidade,Telefone,CRMId")] ClinicoGeral clinicoGeral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clinicoGeral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CRMId"] = new SelectList(_context.Set<CRM>(), "CRMId", "Numero", clinicoGeral.CRMId);
            return View(clinicoGeral);
        }

        // GET: ClinicoGeral/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClinicoGerais == null)
            {
                return NotFound();
            }

            var clinicoGeral = await _context.ClinicoGerais.FindAsync(id);
            if (clinicoGeral == null)
            {
                return NotFound();
            }
            ViewData["CRMId"] = new SelectList(_context.Set<CRM>(), "CRMId", "Numero", clinicoGeral.CRMId);
            return View(clinicoGeral);
        }

        // POST: ClinicoGeral/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Especialidade,Telefone,CRMId")] ClinicoGeral clinicoGeral)
        {
            if (id != clinicoGeral.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clinicoGeral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClinicoGeralExists(clinicoGeral.Id))
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
            ViewData["CRMId"] = new SelectList(_context.Set<CRM>(), "CRMId", "Numero", clinicoGeral.CRMId);
            return View(clinicoGeral);
        }

        // GET: ClinicoGeral/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClinicoGerais == null)
            {
                return NotFound();
            }

            var clinicoGeral = await _context.ClinicoGerais
                .Include(c => c.CRM)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clinicoGeral == null)
            {
                return NotFound();
            }

            return View(clinicoGeral);
        }

        // POST: ClinicoGeral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClinicoGerais == null)
            {
                return Problem("Entity set 'FIAPDbContext.ClinicoGerais'  is null.");
            }
            var clinicoGeral = await _context.ClinicoGerais.FindAsync(id);
            if (clinicoGeral != null)
            {
                _context.ClinicoGerais.Remove(clinicoGeral);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClinicoGeralExists(int id)
        {
          return (_context.ClinicoGerais?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
