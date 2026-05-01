using CasosDeUsos.DTOs.TipoDeGastoDTO;
using CasosDeUsos.InterfacesCU.TipoDeGastoCU;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;

namespace LogicaDeAplicacion.CasosDeUso.CUTiposDeGasto
{
    public class CUListadoTipoDeGasto : ICUListadoTipoDeGasto
    {
        public IRepositorioTipoDeGasto RepoTipoDeGasto { get; set; }

        public CUListadoTipoDeGasto(IRepositorioTipoDeGasto repoTipoDeGasto)
        {
            RepoTipoDeGasto = repoTipoDeGasto;
        }
        public IEnumerable<TipoDeGastoListadoDto> Ejecutar()
        {
            IEnumerable<TipoDeGasto> tipoDeGastos = RepoTipoDeGasto.GetAll();
            return TipoDeGastoMapper.TipoDeGastoListadoToTipoDeGastoListadoDto(tipoDeGastos);
        }
   
    }
}
