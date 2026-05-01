
using CasosDeUsos.DTOs.PagoDto;

namespace CasosDeUsos.InterfacesCU.PagoCU
{
    public interface ICUAgregarPago
    {
        void Ejecutar(PagoDto pagoDto);
    }
}
