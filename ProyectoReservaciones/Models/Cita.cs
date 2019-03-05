using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoReservaciones.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Nota { get; set; }
        public DateTime Fecha { get; set; }
        public float Precio { get; set; }
        public bool Estado { get; set; }
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }
        public Medicos Medico { get; set; }
        public int MedicoId { get; set; }
        [Display(Name = "Metodo de Pago")]
        public string MetodoPago { get; set; }
    }
}
