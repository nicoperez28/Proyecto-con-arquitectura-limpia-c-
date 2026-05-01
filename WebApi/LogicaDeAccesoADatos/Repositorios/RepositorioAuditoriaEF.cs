using ExcepcionesPropias.ExcepcionesEntidades;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;
using Microsoft.EntityFrameworkCore;

namespace LogicaDeAccesoADatos.Repositorios
{
    public class RepositorioAuditoriaEF : IRepositorioAuditoria
    {
        public Contexto Contexto { get; set; }
        public RepositorioAuditoriaEF(Contexto contexto)
        {
            Contexto = contexto;
        }
        public void Add(Auditoria item)
        {
            if (item != null)
            {
                Contexto.Auditorias.Add(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new TipoDeGastoException("Datos Invalidos");
            }
        }

        public IEnumerable<Auditoria> ListadoDeAuditoria(int idAuditado) 
        {
            return Contexto.Auditorias
                    .Include(a => a.TipoDeGasto)
                    .Where(a =>  a.TipoDeGasto.Id == idAuditado)
                    .ToList();
        }
    }
}
