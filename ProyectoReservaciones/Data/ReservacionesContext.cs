using Microsoft.EntityFrameworkCore;
using ProyectoReservaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoReservaciones.Data
{
    public class ReservacionesContext : DbContext
    {
        public ReservacionesContext(DbContextOptions<ReservacionesContext> options) : base(options) { }
        public DbSet<Medicos> Medicos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Cita> Citas { get; set; }

    }
}
