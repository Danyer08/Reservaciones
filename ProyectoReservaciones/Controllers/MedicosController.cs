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
    public class MedicosController : Controller
    {
        private readonly ReservacionesContext _context;

        public MedicosController(ReservacionesContext context)
        {
            _context = context;
        }

        // GET: Medicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Medicos.ToListAsync());
        }

        // GET: Medicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicos = await _context.Medicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicos == null)
            {
                return NotFound();
            }

            return View(medicos);
        }

        // GET: Medicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Genero,Telefono,Correo,Direccion,Especialidad")] Medicos medicos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicos);
        }

        // GET: Medicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicos = await _context.Medicos.FindAsync(id);
            if (medicos == null)
            {
                return NotFound();
            }
            return View(medicos);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Genero,Telefono,Correo,Direccion,Especialidad")] Medicos medicos)
        {
            if (id != medicos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicosExists(medicos.Id))
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
            return View(medicos);
        }

        // GET: Medicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicos = await _context.Medicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicos == null)
            {
                return NotFound();
            }

            return View(medicos);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicos = await _context.Medicos.FindAsync(id);
            _context.Medicos.Remove(medicos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicosExists(int id)
        {
            return _context.Medicos.Any(e => e.Id == id);
        }
    }
}
