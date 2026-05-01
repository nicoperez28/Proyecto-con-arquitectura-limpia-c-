using CasosDeUsos.DTOs.TipoDeGastoDTO;

namespace CasosDeUsos.InterfacesCU.TipoDeGastoCU
{
    public interface ICUAddTipoDeGasto
    {
        void Ejecutar(TipoDeGastoDto tipoDeGastoDto);
    }
}
