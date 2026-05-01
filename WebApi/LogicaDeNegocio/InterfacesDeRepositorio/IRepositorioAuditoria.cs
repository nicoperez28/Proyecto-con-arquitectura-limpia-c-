using LogicaDeNegocio.EntidadesDeNegocio;

namespace LogicaDeNegocio.InterfacesDeRepositorio
{
    public interface IRepositorioAuditoria
    {
        void Add(Auditoria item);
         IEnumerable<Auditoria> ListadoDeAuditoria(int id);
    }
}
