namespace CasosDeUsos.DTOs.PagoDto
{
    public class PagoDetalleDto
    {
        public int Id { get; set; }
        public string TipoDePago { get; set; }
        public string MetodoDePago { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }
        public string TipoDeGasto { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioApellido { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
    }
}
