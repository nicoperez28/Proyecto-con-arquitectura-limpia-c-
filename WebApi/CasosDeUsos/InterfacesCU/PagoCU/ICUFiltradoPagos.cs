using CasosDeUsos.DTOs.PagoDto;

namespace CasosDeUsos.InterfacesCU.PagoCU
{
    public interface ICUFiltradoPagos
    {
        IEnumerable<PagoFiltradoDto> Ejecutar(DateTime fechaFiltro);
    }
}
