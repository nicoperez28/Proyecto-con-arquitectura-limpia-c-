using CasosDeUsos.DTOs.EquipoDTO;

namespace CasosDeUsos.InterfacesCU.EquipoCU
{
    public interface ICUListarEquipo
    {
        IEnumerable<EquipoListadoDto> Ejecutar();
    }
}
