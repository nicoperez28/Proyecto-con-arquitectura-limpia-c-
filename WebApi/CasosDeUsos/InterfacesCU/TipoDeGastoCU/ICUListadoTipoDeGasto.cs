using CasosDeUsos.DTOs.TipoDeGastoDTO;


namespace CasosDeUsos.InterfacesCU.TipoDeGastoCU
{
    public interface ICUListadoTipoDeGasto
    {
        IEnumerable<TipoDeGastoListadoDto> Ejecutar();
    }
}
