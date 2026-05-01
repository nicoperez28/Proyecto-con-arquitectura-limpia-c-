using CasosDeUsos.DTOs.Rol;
namespace CasosDeUsos.InterfacesCU.RolCU
{
    public interface ICUListarRol
    {
        IEnumerable<RolListadoDto> Ejecutar();
    }
}
