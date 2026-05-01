using CasosDeUsos.DTOs.EquipoDTO;
using CasosDeUsos.DTOs.PagoDto;

namespace CasosDeUsos.InterfacesCU.PagoCU
{
    public interface ICUFiltrarPagoPorMonto
    {
        IEnumerable<EquipoListadoDto> Ejecutar(double monto);
    }
}
