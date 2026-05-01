namespace CasosDeUsos.DTOs.PagoDto
{
    public class PagoFiltradoMontoDto
    {
        public int Id { get; set; }
        public double Monto { get; set; }
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
    }
}
