using CasosDeUsos.DTOs.TipoDeGastoDTO;
using CasosDeUsos.InterfacesCU.TipoDeGastoCU;
using ExcepcionesPropias.ExcepcionesEntidades;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;

namespace LogicaDeAplicacion.CasosDeUso.CUTiposDeGasto
{
    public class CUBuscarTipoDeGasto : ICUBuscarTipoDeGasto
    {
        IRepositorioTipoDeGasto RepoTipoDeGasto { get; set; }

        public CUBuscarTipoDeGasto(IRepositorioTipoDeGasto repoTipoDeGasto)
        {
            RepoTipoDeGasto = repoTipoDeGasto;
        }

        public TipoDeGastoListadoDto Ejecutar(int id)
        {
            TipoDeGasto tipoDeGasto = RepoTipoDeGasto.GetById(id);
            if (tipoDeGasto != null)
            {
                return TipoDeGastoMapper.TipoDeGastoToTipoDeGastoListadoDto(tipoDeGasto);
            }
            else
            {
                throw new TipoDeGastoException("Tipo de Gasto no encontrado");
            }

        }
    }
}
