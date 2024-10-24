namespace FrontendProject.Models
{
    public class Turno
    {
        public required string NombreCliente { get; set; }
        public required string CorreoCliente { get; set; }
        public required string TelefonoCliente { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; } // Cambiado de string a TimeSpan
        public int SucursalId { get; set; }
        public required Estado Estado { get; set; }
    }

    public class Estado
    {
        public int Id { get; set; }
    }
}
