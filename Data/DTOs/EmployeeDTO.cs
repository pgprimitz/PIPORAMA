using System.Text.Json.Serialization;
using TP_ProgramaciónII_PIPORAMA.Data.Models;

namespace TP_ProgramaciónII_PIPORAMA.Data.DTOs
{
    public class EmployeeDTO
    {
        public int IdEmpleado { get; set; }

        public string NomEmpleado { get; set; }

        public string ApeEmpleado { get; set; }

        public int IdBarrio { get; set; }

        public int IdContacto { get; set; }

        public NeighborhoodDTO Barrio { get; set; }
        public ContactDTO Contacto { get; set; }
    }
}
