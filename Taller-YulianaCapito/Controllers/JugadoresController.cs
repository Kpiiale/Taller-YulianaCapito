using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Taller_YulianaCapito.Data;
using Taller_YulianaCapito.Models;

namespace Taller_YulianaCapito.Controllers
{
    public class JugadoresController : Controller
    {
        private readonly Taller_YulianaCapitoContext _context;

        public JugadoresController(Taller_YulianaCapitoContext context)
        {
            _context = context;
        }

        // GET: Jugadores
        public async Task<IActionResult> Index(int? equipoId)
            // Modificado con ChatGPT debido a que tenia un error de NullPointerException
        {
            ViewBag.Equipos = _context.Equipo.ToList(); 
            var jugadores = _context.Jugadores.Include(j => j.Equipo).ToList();

            if (equipoId.HasValue)
            {
                jugadores = jugadores.Where(j => j.IdEquipo == equipoId.Value).ToList();
            }

            return View(jugadores);
        }

        // GET: Jugadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugadores = await _context.Jugadores
                .Include(j => j.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugadores == null)
            {
                return NotFound();
            }

            return View(jugadores);
        }

        // GET: Jugadores/Create
        public IActionResult Create()
        {
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Nombre");
            return View();
        }

        // POST: Jugadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Posicion,Edad,IdEquipo")] Jugadores jugadores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jugadores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Nombre", jugadores.IdEquipo);
            return View(jugadores);
        }

        // GET: Jugadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugadores = await _context.Jugadores.FindAsync(id);
            if (jugadores == null)
            {
                return NotFound();
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Nombre", jugadores.IdEquipo);
            return View(jugadores);
        }

        // POST: Jugadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Posicion,Edad,IdEquipo")] Jugadores jugadores)
        {
            if (id != jugadores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugadoresExists(jugadores.Id))
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
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Nombre", jugadores.IdEquipo);
            return View(jugadores);
        }

        // GET: Jugadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugadores = await _context.Jugadores
                .Include(j => j.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugadores == null)
            {
                return NotFound();
            }

            return View(jugadores);
        }

        // POST: Jugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jugadores = await _context.Jugadores.FindAsync(id);
            if (jugadores != null)
            {
                _context.Jugadores.Remove(jugadores);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JugadoresExists(int id)
        {
            return _context.Jugadores.Any(e => e.Id == id);
        }
    }
}
