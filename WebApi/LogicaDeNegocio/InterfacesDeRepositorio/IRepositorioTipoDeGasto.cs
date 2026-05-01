

using LogicaDeNegocio.EntidadesDeNegocio;

namespace LogicaDeNegocio.InterfacesDeRepositorio
{
    public interface IRepositorioTipoDeGasto
    {
        void Add(TipoDeGasto item);
        void Delete(TipoDeGasto item);
        void Update(int id, TipoDeGasto item);
        TipoDeGasto GetById(int id);
        IEnumerable<TipoDeGasto> GetAll();
    }
}
