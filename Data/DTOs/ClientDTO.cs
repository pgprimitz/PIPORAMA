namespace TP_ProgramaciónII_PIPORAMA.Data.DTOs
{
    public class ClientDTO
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int IdTipoCliente { get; set; }
        public int IdBarrio { get; set; }
        public int IdContacto { get; set; }
        public ClientTypeDTO TipoCliente { get; set; }
        public NeighborhoodDTO Barrio { get; set; }
        public ContactDTO Contacto { get; set; }
    }
}
