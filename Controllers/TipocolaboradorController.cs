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
    public class TipocolaboradorController : Controller
    {
        private readonly Contexto _context;

        public TipocolaboradorController(Contexto context)
        {
            _context = context;
        }

        // GET: Tipocolaborador
        public async Task<IActionResult> Index()
        {
              return _context.Tipocolaborador != null ? 
                          View(await _context.Tipocolaborador.ToListAsync()) :
                          Problem("Entity set 'Contexto.Tipocolaborador'  is null.");
        }

        // GET: Tipocolaborador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tipocolaborador == null)
            {
                return NotFound();
            }

            var tipocolaborador = await _context.Tipocolaborador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipocolaborador == null)
            {
                return NotFound();
            }

            return View(tipocolaborador);
        }

        // GET: Tipocolaborador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipocolaborador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoColaboradorNome")] Tipocolaborador tipocolaborador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipocolaborador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipocolaborador);
        }

        // GET: Tipocolaborador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tipocolaborador == null)
            {
                return NotFound();
            }

            var tipocolaborador = await _context.Tipocolaborador.FindAsync(id);
            if (tipocolaborador == null)
            {
                return NotFound();
            }
            return View(tipocolaborador);
        }

        // POST: Tipocolaborador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoColaboradorNome")] Tipocolaborador tipocolaborador)
        {
            if (id != tipocolaborador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipocolaborador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipocolaboradorExists(tipocolaborador.Id))
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
            return View(tipocolaborador);
        }

        // GET: Tipocolaborador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tipocolaborador == null)
            {
                return NotFound();
            }

            var tipocolaborador = await _context.Tipocolaborador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipocolaborador == null)
            {
                return NotFound();
            }

            return View(tipocolaborador);
        }

        // POST: Tipocolaborador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tipocolaborador == null)
            {
                return Problem("Entity set 'Contexto.Tipocolaborador'  is null.");
            }
            var tipocolaborador = await _context.Tipocolaborador.FindAsync(id);
            if (tipocolaborador != null)
            {
                _context.Tipocolaborador.Remove(tipocolaborador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipocolaboradorExists(int id)
        {
          return (_context.Tipocolaborador?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
