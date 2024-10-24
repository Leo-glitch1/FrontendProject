using System.ComponentModel.DataAnnotations;

namespace FrontendProject.Models
{
    public class Turno
    {
        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        public required string NombreCliente { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public required string CorreoCliente { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El teléfono no es válido.")]
        public required string TelefonoCliente { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La hora es obligatoria.")]
        public TimeSpan Hora { get; set; }

        [Required(ErrorMessage = "El estado del turno es obligatorio.")]
        public required Estado Estado { get; set; }

        public int SucursalId { get; set; }
    }

    public class Estado
    {
        public int Id { get; set; }
    }
}
