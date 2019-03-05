using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoReservaciones.Data;
using ProyectoReservaciones.Models;

namespace ProyectoReservaciones.Controllers
{
    public class CitasController : Controller
    {
        private readonly ReservacionesContext _context;

        public CitasController(ReservacionesContext context)
        {
            _context = context;
        }

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            var reservacionesContext = _context.Citas.Include(c => c.Medico).Include(c => c.Paciente);
            return View(await reservacionesContext.ToListAsync());
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Id");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Id");
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Nota,Fecha,Precio,Estado,PacienteId,MedicoId,MetodoPago")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Id", cita.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Id", cita.PacienteId);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Id", cita.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Id", cita.PacienteId);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Nota,Fecha,Precio,Estado,PacienteId,MedicoId,MetodoPago")] Cita cita)
        {
            if (id != cita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaExists(cita.Id))
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
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Id", cita.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Id", cita.PacienteId);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(int id)
        {
            return _context.Citas.Any(e => e.Id == id);
        }
    }
}
