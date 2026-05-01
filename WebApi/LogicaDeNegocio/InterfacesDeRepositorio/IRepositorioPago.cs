

using LogicaDeNegocio.EntidadesDeNegocio;

namespace LogicaDeNegocio.InterfacesDeRepositorio
{
    public interface IRepositorioPago : IRepositorio<Pago>
    {
        public void Add(Pago item);

        public IEnumerable<Pago> GetAll();

        public Pago GetById(int id);

        public IEnumerable<Pago> GetAllPagoUnico(DateTime fechaFiltro);
        public IEnumerable<Pago> GetAllRecurrente(DateTime fechaFiltro);
        public IEnumerable<Pago> FiltrarPagoUnico(double monto);
        public IEnumerable<Equipo> FiltrarPagoUnicoPorMonto(double monto);
        public IEnumerable<Pago> FiltrarPagoPorMail(string mail);
    }
}
