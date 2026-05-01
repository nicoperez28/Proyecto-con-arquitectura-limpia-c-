
using CasosDeUsos.DTOs.EquipoDTO;
using CasosDeUsos.DTOs.Rol;
using CasosDeUsos.InterfacesCU.RolCU;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;

namespace LogicaDeAplicacion.CasosDeUso.CURol
{
    public class CUListarRol : ICUListarRol
    {
        public IRepositorioRol RepoRoles { get; set; }

        public CUListarRol(IRepositorioRol repoRoles)
        {
            RepoRoles = repoRoles;
        }
        public IEnumerable<RolListadoDto> Ejecutar()
        {
            IEnumerable<Rol> roles = RepoRoles.GetAll();
            return RolMapper.RolListadoToRolListadoDto(roles);
        }

    }
}
