
using CasosDeUsos.DTOs.EquipoDTO;
using CasosDeUsos.DTOs.Rol;
using LogicaDeNegocio.EntidadesDeNegocio;

namespace LogicaDeAplicacion.Mappers
{
    public class RolMapper
    {
        public static IEnumerable<RolListadoDto>
            RolListadoToRolListadoDto(IEnumerable<Rol> roles)
        {
            List<RolListadoDto> rolListado = new List<RolListadoDto>();
            foreach (Rol rol in roles)
            {
                rolListado.Add(new RolListadoDto()
                {
                    Id = rol.Id,
                    Tipo = rol.Tipo,
                });
            }
            return rolListado;

        }
    }
}
