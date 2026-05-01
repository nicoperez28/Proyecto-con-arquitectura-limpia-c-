using CasosDeUsos.DTOs.TipoDeGastoDTO;

namespace CasosDeUsos.DTOs.PagoDto
{
    public class PagoDto
    {
        public string TipoDePago { get; set; }
        public string MetodoDePago { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }
        public int TipoDeGastoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaHasta { get; set; }
        public IEnumerable<TipoDeGastoListadoDto> tiposDeGasto { get; set; } = new List<TipoDeGastoListadoDto>();
        public IEnumerable<string> MetodosDePago { get; set; } = new List<string>();

    }
}
