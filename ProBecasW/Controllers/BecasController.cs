
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProBecasW.Data;
using ProBecasW.Models;
using ProBecasW.Services;
using ProBecasW.Data;
using ProBecasW.Models;
using ProBecasW.Services;

namespace ProBecasW.Controllers
{
    public class BecasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBecaService _becaService;

        public BecasController(ApplicationDbContext context, IBecaService becaService)
        {
            _context = context;
            _becaService = becaService;
        }

        // GET: Becas
        public async Task<IActionResult> Index()
            => View(await _context.SolicitudesBeca.ToListAsync());

        // GET: Becas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var solicitud = await _context.SolicitudesBeca.FindAsync(id);
            return solicitud == null ? NotFound() : View(solicitud);
        }

        // GET: Becas/Create
        public IActionResult Create() => View();

        // POST: Becas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SolicitudBeca solicitud)
        {
            if (!ModelState.IsValid) return View(solicitud);

            var req = new EvaluacionRequest
            {
                PromedioNotas = solicitud.PromedioNotas,
                IngresoFamiliar = solicitud.IngresoFamiliar,
                IntegrantesFamilia = solicitud.IntegrantesFamilia,
                SituacionLaboral = solicitud.SituacionLaboral
            };
            var eval = _becaService.Evaluar(req);
            solicitud.Puntaje = eval.Puntaje;
            solicitud.Resultado = eval.Resultado;
            solicitud.FechaSolicitud = DateTime.Now;

            _context.Add(solicitud);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Becas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var solicitud = await _context.SolicitudesBeca.FindAsync(id);
            return solicitud == null ? NotFound() : View(solicitud);
        }

        // POST: Becas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SolicitudBeca solicitud)
        {
            if (id != solicitud.IdSolicitud) return NotFound();
            if (!ModelState.IsValid) return View(solicitud);

            var req = new EvaluacionRequest
            {
                PromedioNotas = solicitud.PromedioNotas,
                IngresoFamiliar = solicitud.IngresoFamiliar,
                IntegrantesFamilia = solicitud.IntegrantesFamilia,
                SituacionLaboral = solicitud.SituacionLaboral
            };
            var eval = _becaService.Evaluar(req);
            solicitud.Puntaje = eval.Puntaje;
            solicitud.Resultado = eval.Resultado;

            try
            {
                _context.Update(solicitud);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.SolicitudesBeca.Any(e => e.IdSolicitud == id)) return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Becas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var solicitud = await _context.SolicitudesBeca.FindAsync(id);
            return solicitud == null ? NotFound() : View(solicitud);
        }

        // POST: Becas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitud = await _context.SolicitudesBeca.FindAsync(id);
            if (solicitud != null) _context.SolicitudesBeca.Remove(solicitud);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}