using ExcepcionesPropias.ExcepcionesEntidades;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;

namespace LogicaDeAccesoADatos.Repositorios
{
    public class RepositorioEquipoEF : IRepositorioEquipo
    {
        public Contexto Contexto { get; set; }
        public RepositorioEquipoEF(Contexto contexto)
        {
            Contexto = contexto;
        }

        public void Add(Equipo item)
        {
            throw new NotImplementedException();
        }

        public Equipo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipo> GetAll()
        {
            return Contexto.Equipos;
        }
    }
}
