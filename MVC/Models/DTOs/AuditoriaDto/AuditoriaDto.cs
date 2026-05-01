using MVC.Models.DTOs.TipoDeGastoDTO;

namespace MVC.Models.DTOs.AuditoriaDto

{
    public class AuditoriaDto
    {
        public string Mail { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreTipoDeGasto { get; set; }
        public string DescripcionTipoDeGasto { get; set; }

        public IEnumerable<TipoDeGastoListadoDto> tiposDeGasto { get; set; } = new List<TipoDeGastoListadoDto>();
    }
}
