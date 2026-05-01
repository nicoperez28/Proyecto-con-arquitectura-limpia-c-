using CasosDeUsos.DTOs.EquipoDTO;
using CasosDeUsos.InterfacesCU.EquipoCU;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;

namespace LogicaDeAplicacion.CasosDeUso.CUEquipo
{
    public class CUListarEquipo : ICUListarEquipo
    {
        public IRepositorioEquipo RepoEquipo { get; set; }

        public CUListarEquipo(IRepositorioEquipo repoEquipo)
        {
            RepoEquipo = repoEquipo;
        }
        public IEnumerable<EquipoListadoDto> Ejecutar()
        {
            IEnumerable<Equipo> equipos = RepoEquipo.GetAll();
            return EquipoMapper.EquipoListadoToEquipoListadoDto(equipos);
        }
    }
}
