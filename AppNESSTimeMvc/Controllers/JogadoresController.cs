using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppNESSTimeMvc.Data;
using AppNESSTimeMvc.Models;

namespace AppNESSTimeMvc.Controllers
{
    public class JogadoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JogadoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("lista-jogadores")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Jogador.Include(j => j.Time);
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogador
                .Include(j => j.Time)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        [Route("novo-jogador")]
        public IActionResult Create()
        {
            ViewData["TimeId"] = new SelectList(_context.Time, "Id", "Nome");
            return View();
        }

        [Route("novo-jogador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                jogador.Id = Guid.NewGuid();
                _context.Add(jogador);
                await _context.SaveChangesAsync();
                TempData["NovoJogador"] = "Novo Atleta salvo com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["TimeId"] = new SelectList(_context.Time, "Id", "Nome", jogador.TimeId);
            return View(jogador);
        }

       [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogador.FindAsync(id);
            if (jogador == null)
            {
                return NotFound();
            }
            ViewData["TimeId"] = new SelectList(_context.Time, "Id", "Nome", jogador.TimeId);
            return View(jogador);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Jogador jogador)
        {
            if (id != jogador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogadorExists(jogador.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["EditJogador"] = "Jogador editado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["TimeId"] = new SelectList(_context.Time, "Id", "Nome", jogador.TimeId);
            return View(jogador);
        }

       [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogador
                .Include(j => j.Time)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }
 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var jogador = await _context.Jogador.FindAsync(id);
            _context.Jogador.Remove(jogador);
            await _context.SaveChangesAsync();
            TempData["DeleteJogador"] = "Jogador excluído!";
            return RedirectToAction(nameof(Index));
        }

        private bool JogadorExists(Guid id)
        {
            return _context.Jogador.Any(e => e.Id == id);
        }
    }
}
