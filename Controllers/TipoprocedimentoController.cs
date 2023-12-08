using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoFinalVitor.Models;

namespace ProjetoFinalVitor.Controllers
{
    public class TipoprocedimentoController : Controller
    {
        private readonly Contexto _context;

        public TipoprocedimentoController(Contexto context)
        {
            _context = context;
        }

        // GET: Tipoprocedimento
        public async Task<IActionResult> Index()
        {
              return _context.Tipoprocedimento != null ? 
                          View(await _context.Tipoprocedimento.ToListAsync()) :
                          Problem("Entity set 'Contexto.Tipoprocedimento'  is null.");
        }

        // GET: Tipoprocedimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tipoprocedimento == null)
            {
                return NotFound();
            }

            var tipoprocedimento = await _context.Tipoprocedimento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoprocedimento == null)
            {
                return NotFound();
            }

            return View(tipoprocedimento);
        }

        // GET: Tipoprocedimento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipoprocedimento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoProcedimentoNome")] Tipoprocedimento tipoprocedimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoprocedimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoprocedimento);
        }

        // GET: Tipoprocedimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tipoprocedimento == null)
            {
                return NotFound();
            }

            var tipoprocedimento = await _context.Tipoprocedimento.FindAsync(id);
            if (tipoprocedimento == null)
            {
                return NotFound();
            }
            return View(tipoprocedimento);
        }

        // POST: Tipoprocedimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoProcedimentoNome")] Tipoprocedimento tipoprocedimento)
        {
            if (id != tipoprocedimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoprocedimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoprocedimentoExists(tipoprocedimento.Id))
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
            return View(tipoprocedimento);
        }

        // GET: Tipoprocedimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tipoprocedimento == null)
            {
                return NotFound();
            }

            var tipoprocedimento = await _context.Tipoprocedimento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoprocedimento == null)
            {
                return NotFound();
            }

            return View(tipoprocedimento);
        }

        // POST: Tipoprocedimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tipoprocedimento == null)
            {
                return Problem("Entity set 'Contexto.Tipoprocedimento'  is null.");
            }
            var tipoprocedimento = await _context.Tipoprocedimento.FindAsync(id);
            if (tipoprocedimento != null)
            {
                _context.Tipoprocedimento.Remove(tipoprocedimento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoprocedimentoExists(int id)
        {
          return (_context.Tipoprocedimento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
