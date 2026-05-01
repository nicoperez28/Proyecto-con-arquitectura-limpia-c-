using ExcepcionesPropias.ExcepcionesEntidades;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;
using Microsoft.EntityFrameworkCore;

namespace LogicaDeAccesoADatos.Repositorios
{
    public class RepositorioPagoEF : IRepositorioPago
    {
        public Contexto Contexto { get; set; }
        public RepositorioPagoEF(Contexto contexto)
        {
            Contexto = contexto;
        }
        public void Add(Pago item)
        {
            if (item != null)
            {
                Contexto.Pagos.Add(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new PagoException("Datos Invalidos");
            }
        }

        public IEnumerable<Pago> GetAll()
        {
            return Contexto.Pagos
                       .Include(p => p.TipoDeGasto)
                       .Include(p => p.Usuario)
                       .ToList();
        }

        public Pago GetById(int id)
        {
            return Contexto.Pagos
                .Include(p => p.TipoDeGasto)
                .Include(p => p.Usuario)
                .Where(p => p.Id == id)
                .SingleOrDefault();
        }

        public IEnumerable<Pago> GetAllPagoUnico(DateTime fechaFiltro)
        {
            bool tienePagos = Contexto.PagosUnicos.Any(p => p.FechaDePago.Month == fechaFiltro.Month &&
                                                            p.FechaDePago.Year == fechaFiltro.Year);

            if (!tienePagos)
            {
                throw new PagoException("No existen registros en esa fecha");
            }

            return Contexto.PagosUnicos
                       .Include(p => p.TipoDeGasto)
                       .Include(p => p.Usuario)
                       .Where(p => p.FechaDePago.Month == fechaFiltro.Month &&
                                   p.FechaDePago.Year == fechaFiltro.Year)
                       .ToList();
        }

        public IEnumerable<Pago> GetAllRecurrente(DateTime fechaFiltro)
        {
            bool tienePagos = Contexto.Recurrentes.Any(p => p.FechaDesde.Month == fechaFiltro.Month &&
                                                            p.FechaDesde.Year == fechaFiltro.Year);
            if (!tienePagos)
            {
                throw new PagoException("No existen registros en esa fecha");
            }

            return Contexto.Recurrentes
                       .Include(p => p.TipoDeGasto)
                       .Include(p => p.Usuario)
                       .Where(p => p.FechaDesde.Month == fechaFiltro.Month &&
                                    p.FechaDesde.Year == fechaFiltro.Year)
                       .ToList();

        }

        public IEnumerable<Equipo> FiltrarPagoUnicoPorMonto(double monto)
        {
            bool tienePagos = Contexto.PagosUnicos.Any(p => p.Monto > monto);

            if (!tienePagos)
            {
                throw new PagoException("No existen registros con ese monto o superior");
            }

            return Contexto.PagosUnicos
                        .Include(p => p.Usuario)
                            .ThenInclude(u => u.Equipo)
                        .Where(p => p.Monto > monto)
                        .Select(p => p.Usuario.Equipo)
                        .Distinct()
                        .OrderByDescending(e => e.Nombre)
                        .ToList();
        }

        public IEnumerable<Pago> FiltrarPagoPorMail(string mail)
        {
            return Contexto.Pagos
                    .Include (p => p.TipoDeGasto)
                    .Include(p => p.Usuario)
                    .Where(p => p.Usuario.Mail == mail);
        }

        IEnumerable<Pago> IRepositorioPago.FiltrarPagoUnico(double monto)
        {
            throw new NotImplementedException();
        }
    }
}
