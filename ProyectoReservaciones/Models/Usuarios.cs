using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoReservaciones.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { get; set; }
    }
}
