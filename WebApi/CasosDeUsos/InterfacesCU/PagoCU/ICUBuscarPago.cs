
using CasosDeUsos.DTOs.PagoDto;

namespace CasosDeUsos.InterfacesCU.PagoCU
{
    public interface ICUBuscarPago
    {
        PagoDetalleDto Ejecutar(int id);
    }
}
