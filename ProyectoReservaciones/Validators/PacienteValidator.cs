using FluentValidation;
using ProyectoReservaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoReservaciones.Validators
{
    public class PacienteValidator : AbstractValidator<Paciente>
    {
        public PacienteValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Nombre).NotEmpty();
            RuleFor(x => x.Apellido).NotEmpty();
            RuleFor(x => x.Cedula).NotEmpty();
            RuleFor(x => x.Direccion).NotEmpty();
            RuleFor(x => x.Telefono).NotEmpty();
            RuleFor(x => x.FechaNacimiento).NotEmpty();
            RuleFor(x => x.Correo).EmailAddress();
        }
    }
}
