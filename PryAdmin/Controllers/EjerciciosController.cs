using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PryAdmin.Models;

namespace PryAdmin.Controllers
{
    [Authorize(Roles = "cli, adm")]
    public class EjerciciosController : Controller
    {
        private readonly WebContext _context;

        public EjerciciosController(WebContext context)
        {
            _context = context;
        }

        // GET: Ejercicios
        public async Task<IActionResult> Index()
        {
            var webContext = _context.Ejercicios.Include(e => e.IdUsuarioNavigation);
            return View(await webContext.ToListAsync());
        }

        // GET: Ejercicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ejercicios == null)
            {
                return NotFound();
            }

            var ejercicio = await _context.Ejercicios
                .Include(e => e.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ejercicio == null)
            {
                return NotFound();
            }

            return View(ejercicio);
        }

        // GET: Ejercicios/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Ejercicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario,Nombre,Repeticiones")] Ejercicio ejercicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ejercicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", ejercicio.IdUsuario);
            return View(ejercicio);
        }

        // GET: Ejercicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ejercicios == null)
            {
                return NotFound();
            }

            var ejercicio = await _context.Ejercicios.FindAsync(id);
            if (ejercicio == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", ejercicio.IdUsuario);
            return View(ejercicio);
        }

        // POST: Ejercicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUsuario,Nombre,Repeticiones")] Ejercicio ejercicio)
        {
            if (id != ejercicio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ejercicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EjercicioExists(ejercicio.Id))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", ejercicio.IdUsuario);
            return View(ejercicio);
        }

        // GET: Ejercicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ejercicios == null)
            {
                return NotFound();
            }

            var ejercicio = await _context.Ejercicios
                .Include(e => e.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ejercicio == null)
            {
                return NotFound();
            }

            return View(ejercicio);
        }

        // POST: Ejercicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ejercicios == null)
            {
                return Problem("Entity set 'WebContext.Ejercicios'  is null.");
            }
            var ejercicio = await _context.Ejercicios.FindAsync(id);
            if (ejercicio != null)
            {
                _context.Ejercicios.Remove(ejercicio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EjercicioExists(int id)
        {
          return _context.Ejercicios.Any(e => e.Id == id);
        }
    }
}
