using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;

namespace LogicaDeAccesoADatos.Repositorios
{
    public class RepositorioRolEF : IRepositorioRol
    {
        public Contexto Contexto { get; set; }
        public RepositorioRolEF(Contexto contexto)
        {
            Contexto = contexto;
        }
        public void Add(Rol item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rol> GetAll()
        {

            return Contexto.Roles
                .Where(r => r.Id != 1)
                .ToList();

        }

        public Rol GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
