
using CasosDeUsos.DTOs.TipoDeGastoDTO;
using CasosDeUsos.InterfacesCU.TipoDeGastoCU;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;

namespace LogicaDeAplicacion.CasosDeUso.CUTiposDeGasto
{
    public class CUAddTipoDeGasto : ICUAddTipoDeGasto
    {
        public IRepositorioTipoDeGasto RepoTipoDeGasto { get; set; }

        public CUAddTipoDeGasto(IRepositorioTipoDeGasto repoTipoDeGasto)
        {
            RepoTipoDeGasto = repoTipoDeGasto;
        }
        public void Ejecutar(TipoDeGastoDto tipoDeGastoDto)
        {
            TipoDeGasto tipoDeGasto = TipoDeGastoMapper.TipoDeGastoDtoToTipoDeGasto(tipoDeGastoDto);
            RepoTipoDeGasto.Add(tipoDeGasto);
        }
    }
}
