
namespace LogicaDeNegocio.InterfacesDeRepositorio
{
    public interface IRepositorio<T>
    {
        void Add(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
