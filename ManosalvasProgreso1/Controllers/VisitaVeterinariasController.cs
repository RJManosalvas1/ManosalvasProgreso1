using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManosalvasProgreso1.Data;
using ManosalvasProgreso1.Models;

namespace ManosalvasProgreso1.Controllers
{
    public class VisitasVeterinariasController : Controller
    {
        private readonly ManosalvasProgreso1Context _context;

        public VisitasVeterinariasController(ManosalvasProgreso1Context context)
        {
            _context = context;
        }

        // GET: VisitasVeterinarias
        public async Task<IActionResult> Index()
        {
            var visitas = _context.VisitasVeterinarias.Include(v => v.Mascota);
            return View(await visitas.ToListAsync());
        }

        // GET: VisitasVeterinarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var visita = await _context.VisitasVeterinarias
                .Include(v => v.Mascota)
                .FirstOrDefaultAsync(m => m.IdVisitaVeterinaria == id);

            if (visita == null) return NotFound();

            return View(visita);
        }

        // GET: VisitasVeterinarias/Create
        public IActionResult Create()
        {
            ViewData["IdMascota"] = new SelectList(_context.Mascota, "IdMascota", "Nombre"); // Reemplaza "Nombre" si prefieres otro campo
            return View();
        }

        // POST: VisitasVeterinarias/Create
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

            ViewData["IdMascota"] = new SelectList(_context.Mascota, "IdMascota", "Nombre", visitaVeterinaria.IdMascota);
            return View(visitaVeterinaria);
        }

        // GET: VisitasVeterinarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var visita = await _context.VisitasVeterinarias.FindAsync(id);
            if (visita == null) return NotFound();

            ViewData["IdMascota"] = new SelectList(_context.Mascota, "IdMascota", "Nombre", visita.IdMascota);
            return View(visita);
        }

        // POST: VisitasVeterinarias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVisitaVeterinaria,FechaVisita,MotivoVisita,RequiereMedicamento,IdMascota")] VisitaVeterinaria visita)
        {
            if (id != visita.IdVisitaVeterinaria) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitaVeterinariaExists(visita.IdVisitaVeterinaria))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdMascota"] = new SelectList(_context.Mascota, "IdMascota", "Nombre", visita.IdMascota);
            return View(visita);
        }

        // GET: VisitasVeterinarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var visita = await _context.VisitasVeterinarias
                .Include(v => v.Mascota)
                .FirstOrDefaultAsync(m => m.IdVisitaVeterinaria == id);

            if (visita == null) return NotFound();

            return View(visita);
        }

        // POST: VisitasVeterinarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visita = await _context.VisitasVeterinarias.FindAsync(id);
            if (visita != null)
            {
                _context.VisitasVeterinarias.Remove(visita);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool VisitaVeterinariaExists(int id)
        {
            return _context.VisitasVeterinarias.Any(e => e.IdVisitaVeterinaria == id);
        }
    }
}

