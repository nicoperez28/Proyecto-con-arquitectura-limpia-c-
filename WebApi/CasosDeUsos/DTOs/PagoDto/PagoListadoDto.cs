namespace CasosDeUsos.DTOs.PagoDto
{
    public class PagoListadoDto
    {
        public int Id { get; set; }
        public string MetodoDePago { get; set; }
        public double Monto { get; set; }
        public int UsuarioId { get; set; }
        public string TipoDeGasto { get; set; }
        public double SaldoAPagar { get; set; }
    }
}
