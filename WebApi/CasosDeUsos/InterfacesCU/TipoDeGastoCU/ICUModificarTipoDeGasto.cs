using CasosDeUsos.DTOs.TipoDeGastoDTO;

namespace CasosDeUsos.InterfacesCU.TipoDeGastoCU
{
    public interface ICUModificarTipoDeGasto
    {
        void Ejecutar(int id, TipoDeGastoListadoDto tipoDeGastoListadoDto);
    }
}
