using ExcepcionesPropias.ExcepcionesEntidades;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;

namespace LogicaDeAccesoADatos.Repositorios
{
    public class RepositorioTipoDeGastoEF : IRepositorioTipoDeGasto
    {
        public Contexto Contexto { get; set; }
        public RepositorioTipoDeGastoEF(Contexto contexto)
        {
            Contexto = contexto;
        }

        public void Add(TipoDeGasto item)
        {
            if (item != null)
            {
                Contexto.TipoDeGastos.Add(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new TipoDeGastoException("Datos Invalidos");
            }
        }

        public void Delete(TipoDeGasto item)
        {
            bool tienePagos = Contexto.Pagos.Any(p => p.TipoDeGastoId == item.Id);

            if (tienePagos)
            {
                throw new TipoDeGastoException("Tipo de gasto asociado a un pago");
            }

            Contexto.TipoDeGastos.Remove(item);
            Contexto.SaveChanges();
        }


        public void Update(int id, TipoDeGasto item)
        {
            item.Validar();
            TipoDeGasto tipoDeGasto = GetById(id);
            if (tipoDeGasto != null)
            {
                tipoDeGasto.Nombre = item.Nombre;
                tipoDeGasto.Descripcion = item.Descripcion;
                Contexto.SaveChanges();
            }
            else
            {
                throw new TipoDeGastoException("El Tipo de Gasto no existe");
            }
        }
        public IEnumerable<TipoDeGasto> GetAll()
        {
            return Contexto.TipoDeGastos;
        }

        public TipoDeGasto GetById(int id)
        {
            return Contexto.TipoDeGastos.Find(id);
        }
    }
}
