using CasosDeUsos.DTOs.TipoDeGastoDTO;


namespace CasosDeUsos.InterfacesCU.TipoDeGastoCU
{
    public interface ICUBuscarTipoDeGasto
    {
        TipoDeGastoListadoDto Ejecutar(int id);
    }
}
