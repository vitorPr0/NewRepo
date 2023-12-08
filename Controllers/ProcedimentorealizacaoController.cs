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
    public class ProcedimentorealizacaoController : Controller
    {
        private readonly Contexto _context;

        public ProcedimentorealizacaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Procedimentorealizacao
        public async Task<IActionResult> Index( string pesquisa)
        {
            if (pesquisa == null)
            {
                var contexto = _context.Procedimentorealizacao.Include(p => p.Cliente).Include(p => p.Colaborador).Include(p => p.LocalRealizacao).Include(p => p.Procedimento);
                return View(await contexto.ToListAsync());
            }
            else
            {
                var contexto = _context.Procedimentorealizacao
                    .Include(p => p.Cliente)
                    .Include(p => p.Colaborador)
                    .Include(p => p.LocalRealizacao)
                    .Include(p => p.Procedimento)
                .Where(x => x.Cliente.ClienteNome.Contains(pesquisa));
                return View(await contexto.ToListAsync());
            }

        }

        // GET: Procedimentorealizacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Procedimentorealizacao == null)
            {
                return NotFound();
            }

            var procedimentorealizacao = await _context.Procedimentorealizacao
                .Include(p => p.Cliente)
                .Include(p => p.Colaborador)
                .Include(p => p.LocalRealizacao)
                .Include(p => p.Procedimento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedimentorealizacao == null)
            {
                return NotFound();
            }

            return View(procedimentorealizacao);
        }

        // GET: Procedimentorealizacao/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "ClienteNome");
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "Id", "ColaboradorNome");
            ViewData["LocalRealizacaoId"] = new SelectList(_context.LocalRealizacao, "Id", "LocalNome");
            ViewData["ProcedimentoId"] = new SelectList(_context.Procedimento, "Id", "ProcedimentoNome");
            return View();
        }

        // POST: Procedimentorealizacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,ProcedimentoId,ColaboradorId,LocalRealizacaoId,DataRealizacao,ObservacaoRealizacao")] Procedimentorealizacao procedimentorealizacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procedimentorealizacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "ClienteNome", procedimentorealizacao.ClienteId);
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "Id", "ColaboradorNome", procedimentorealizacao.ColaboradorId);
            ViewData["LocalRealizacaoId"] = new SelectList(_context.LocalRealizacao, "Id", "LocalNome", procedimentorealizacao.LocalRealizacaoId);
            ViewData["ProcedimentoId"] = new SelectList(_context.Procedimento, "Id", "ProcedimentoNome", procedimentorealizacao.ProcedimentoId);
            return View(procedimentorealizacao);
        }

        // GET: Procedimentorealizacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Procedimentorealizacao == null)
            {
                return NotFound();
            }

            var procedimentorealizacao = await _context.Procedimentorealizacao.FindAsync(id);
            if (procedimentorealizacao == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "ClienteNome", procedimentorealizacao.ClienteId);
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "Id", "ColaboradorNome", procedimentorealizacao.ColaboradorId);
            ViewData["LocalRealizacaoId"] = new SelectList(_context.LocalRealizacao, "Id", "LocalNome", procedimentorealizacao.LocalRealizacaoId);
            ViewData["ProcedimentoId"] = new SelectList(_context.Procedimento, "Id", "ProcedimentoNome", procedimentorealizacao.ProcedimentoId);
            return View(procedimentorealizacao);
        }

        // POST: Procedimentorealizacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,ProcedimentoId,ColaboradorId,LocalRealizacaoId,DataRealizacao,ObservacaoRealizacao")] Procedimentorealizacao procedimentorealizacao)
        {
            if (id != procedimentorealizacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedimentorealizacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedimentorealizacaoExists(procedimentorealizacao.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "ClienteNome", procedimentorealizacao.ClienteId);
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "Id", "ColaboradorNome", procedimentorealizacao.ColaboradorId);
            ViewData["LocalRealizacaoId"] = new SelectList(_context.LocalRealizacao, "Id", "LocalNome", procedimentorealizacao.LocalRealizacaoId);
            ViewData["ProcedimentoId"] = new SelectList(_context.Procedimento, "Id", "ProcedimentoNome", procedimentorealizacao.ProcedimentoId);
            return View(procedimentorealizacao);
        }

        // GET: Procedimentorealizacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Procedimentorealizacao == null)
            {
                return NotFound();
            }

            var procedimentorealizacao = await _context.Procedimentorealizacao
                .Include(p => p.Cliente)
                .Include(p => p.Colaborador)
                .Include(p => p.LocalRealizacao)
                .Include(p => p.Procedimento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedimentorealizacao == null)
            {
                return NotFound();
            }

            return View(procedimentorealizacao);
        }

        // POST: Procedimentorealizacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Procedimentorealizacao == null)
            {
                return Problem("Entity set 'Contexto.Procedimentorealizacao'  is null.");
            }
            var procedimentorealizacao = await _context.Procedimentorealizacao.FindAsync(id);
            if (procedimentorealizacao != null)
            {
                _context.Procedimentorealizacao.Remove(procedimentorealizacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedimentorealizacaoExists(int id)
        {
          return (_context.Procedimentorealizacao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Imprimir(int? id)
        {
            if (id == null || _context.Procedimentorealizacao == null)
            {
                return NotFound();
            }

            var resultado = await _context.Procedimentorealizacao
                .Include(p => p.Cliente)
                .Include(p => p.Colaborador)
                .Include(p => p.LocalRealizacao)
                .Include(p => p.Procedimento)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (resultado == null)
            {
                return NotFound();
            }
            return View(resultado);
        }
    }
}
