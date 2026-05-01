
using CasosDeUsos.DTOs.PagoDto;

namespace CasosDeUsos.InterfacesCU.PagoCU
{
    public interface ICUListadoPago
    {
        IEnumerable<PagoListadoDto> Ejecutar();
    }
}
