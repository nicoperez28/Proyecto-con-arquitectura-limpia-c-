using CasosDeUsos.DTOs.TipoDeGastoDTO;
using CasosDeUsos.InterfacesCU.TipoDeGastoCU;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;

namespace LogicaDeAplicacion.CasosDeUso.CUTiposDeGasto
{
    public class CUModificarTipoDeGasto : ICUModificarTipoDeGasto
    {
        public IRepositorioTipoDeGasto RepoTipoDeGasto { get; set; }

        public CUModificarTipoDeGasto(IRepositorioTipoDeGasto repoTipoDeGasto)
        {
            RepoTipoDeGasto = repoTipoDeGasto;
        }

        public void Ejecutar(int id, TipoDeGastoListadoDto tipoDeGastoListadoDto)
        {
            TipoDeGasto tipoDeGasto = TipoDeGastoMapper.EditarTipoDeGastoDtoToTipoDeGasto(id, tipoDeGastoListadoDto);

            RepoTipoDeGasto.Update(id, tipoDeGasto);
        }

    }
}
