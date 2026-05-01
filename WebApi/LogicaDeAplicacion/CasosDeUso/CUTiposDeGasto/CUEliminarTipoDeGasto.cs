using CasosDeUsos.InterfacesCU.TipoDeGastoCU;
using ExcepcionesPropias.ExcepcionesEntidades;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;

namespace LogicaDeAplicacion.CasosDeUso.CUTiposDeGasto
{
    public class CUEliminarTipoDeGasto : ICUEliminarTipoDeGasto
    {
        public IRepositorioTipoDeGasto RepoTipoDeGasto { get; set; }

        public CUEliminarTipoDeGasto(IRepositorioTipoDeGasto repoTipoDeGasto)
        {
            RepoTipoDeGasto = repoTipoDeGasto;
        }

        public void Ejecutar(int id)
        {
            TipoDeGasto tipoDeGasto = RepoTipoDeGasto.GetById(id);
            if (tipoDeGasto != null)
            {
                RepoTipoDeGasto.Delete(tipoDeGasto);
            }
            else
            {
                throw new TipoDeGastoException("El tipo de gasto no existe");
            }
        }
    }
}
