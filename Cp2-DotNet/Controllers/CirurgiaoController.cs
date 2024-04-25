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
    public class CirurgiaoController : Controller
    {
        private readonly FIAPDbContext _context;

        public CirurgiaoController(FIAPDbContext context)
        {
            _context = context;
        }

        // GET: Cirurgiao
        public async Task<IActionResult> Index()
        {
            var fIAPDbContext = _context.Cirurgioes.Include(c => c.CRM);
            return View(await fIAPDbContext.ToListAsync());
        }

        // GET: Cirurgiao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cirurgioes == null)
            {
                return NotFound();
            }

            var cirurgiao = await _context.Cirurgioes
                .Include(c => c.CRM)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cirurgiao == null)
            {
                return NotFound();
            }

            return View(cirurgiao);
        }

        // GET: Cirurgiao/Create
        public IActionResult Create()
        {
            ViewData["CRMId"] = new SelectList(_context.Set<CRM>(), "CRMId", "Numero");
            return View();
        }

        // POST: Cirurgiao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Especialidade,Telefone,CRMId")] Cirurgiao cirurgiao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cirurgiao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CRMId"] = new SelectList(_context.Set<CRM>(), "CRMId", "Numero", cirurgiao.CRMId);
            return View(cirurgiao);
        }

        // GET: Cirurgiao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cirurgioes == null)
            {
                return NotFound();
            }

            var cirurgiao = await _context.Cirurgioes.FindAsync(id);
            if (cirurgiao == null)
            {
                return NotFound();
            }
            ViewData["CRMId"] = new SelectList(_context.Set<CRM>(), "CRMId", "Numero", cirurgiao.CRMId);
            return View(cirurgiao);
        }

        // POST: Cirurgiao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Especialidade,Telefone,CRMId")] Cirurgiao cirurgiao)
        {
            if (id != cirurgiao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cirurgiao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CirurgiaoExists(cirurgiao.Id))
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
            ViewData["CRMId"] = new SelectList(_context.Set<CRM>(), "CRMId", "Numero", cirurgiao.CRMId);
            return View(cirurgiao);
        }

        // GET: Cirurgiao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cirurgioes == null)
            {
                return NotFound();
            }

            var cirurgiao = await _context.Cirurgioes
                .Include(c => c.CRM)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cirurgiao == null)
            {
                return NotFound();
            }

            return View(cirurgiao);
        }

        // POST: Cirurgiao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cirurgioes == null)
            {
                return Problem("Entity set 'FIAPDbContext.Cirurgioes'  is null.");
            }
            var cirurgiao = await _context.Cirurgioes.FindAsync(id);
            if (cirurgiao != null)
            {
                _context.Cirurgioes.Remove(cirurgiao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CirurgiaoExists(int id)
        {
          return (_context.Cirurgioes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
