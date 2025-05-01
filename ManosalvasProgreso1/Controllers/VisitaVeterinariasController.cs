using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManosalvasProgreso1.Data;
using ManosalvasProgreso1.Models;

namespace ManosalvasProgreso1.Controllers
{
    public class VisitaVeterinariasController : Controller
    {
        private readonly ManosalvasProgreso1Context _context;

        public VisitaVeterinariasController(ManosalvasProgreso1Context context)
        {
            _context = context;
        }

        // GET: VisitaVeterinarias
        public async Task<IActionResult> Index()
        {
            var manosalvasProgreso1Context = _context.VisitaVeterinaria.Include(v => v.Mascota);
            return View(await manosalvasProgreso1Context.ToListAsync());
        }

        // GET: VisitaVeterinarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitaVeterinaria = await _context.VisitaVeterinaria
                .Include(v => v.Mascota)
                .FirstOrDefaultAsync(m => m.IdVisitaVeterinaria == id);
            if (visitaVeterinaria == null)
            {
                return NotFound();
            }

            return View(visitaVeterinaria);
        }

        // GET: VisitaVeterinarias/Create
        public IActionResult Create()
        {
            ViewData["IdMascota"] = new SelectList(_context.Mascota, "IdMascota", "IdMascota");
            return View();
        }

        // POST: VisitaVeterinarias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVisitaVeterinaria,FechaVisita,MotivoVisita,RequiereMedicamento,IdMascota")] VisitaVeterinaria visitaVeterinaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitaVeterinaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMascota"] = new SelectList(_context.Mascota, "IdMascota", "IdMascota", visitaVeterinaria.IdMascota);
            return View(visitaVeterinaria);
        }

        // GET: VisitaVeterinarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitaVeterinaria = await _context.VisitaVeterinaria.FindAsync(id);
            if (visitaVeterinaria == null)
            {
                return NotFound();
            }
            ViewData["IdMascota"] = new SelectList(_context.Mascota, "IdMascota", "IdMascota", visitaVeterinaria.IdMascota);
            return View(visitaVeterinaria);
        }

        // POST: VisitaVeterinarias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVisitaVeterinaria,FechaVisita,MotivoVisita,RequiereMedicamento,IdMascota")] VisitaVeterinaria visitaVeterinaria)
        {
            if (id != visitaVeterinaria.IdVisitaVeterinaria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitaVeterinaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitaVeterinariaExists(visitaVeterinaria.IdVisitaVeterinaria))
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
            ViewData["IdMascota"] = new SelectList(_context.Mascota, "IdMascota", "IdMascota", visitaVeterinaria.IdMascota);
            return View(visitaVeterinaria);
        }

        // GET: VisitaVeterinarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitaVeterinaria = await _context.VisitaVeterinaria
                .Include(v => v.Mascota)
                .FirstOrDefaultAsync(m => m.IdVisitaVeterinaria == id);
            if (visitaVeterinaria == null)
            {
                return NotFound();
            }

            return View(visitaVeterinaria);
        }

        // POST: VisitaVeterinarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitaVeterinaria = await _context.VisitaVeterinaria.FindAsync(id);
            if (visitaVeterinaria != null)
            {
                _context.VisitaVeterinaria.Remove(visitaVeterinaria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitaVeterinariaExists(int id)
        {
            return _context.VisitaVeterinaria.Any(e => e.IdVisitaVeterinaria == id);
        }
    }
}
