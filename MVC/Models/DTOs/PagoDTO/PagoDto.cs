using MVC.Models.DTOs.TipoDeGastoDTO;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.DTOs.PagoDTO
{
    public class PagoDto
    {
        public string TipoDePago { get; set; }
        public string MetodoDePago { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(200, ErrorMessage = "La descripción no puede superar los 200 caracteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El monto es obligatorio")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El monto debe ser numérico")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        public double Monto { get; set; }
        public int TipoDeGastoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaHasta { get; set; }

        public IEnumerable<TipoDeGastoListadoDto> tiposDeGasto { get; set; } = new List<TipoDeGastoListadoDto>();
        public IEnumerable<string> MetodosDePago { get; set; } = new List<string>();
    }
}
