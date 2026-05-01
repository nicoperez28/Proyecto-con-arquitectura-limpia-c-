

namespace LogicaDeNegocio.EntidadesDeNegocio
{
    public class Recurrente : Pago
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        public Recurrente(MetodoDePago metodoDePago, string descripcion, double monto, TipoDeGasto tipoDeGasto, Usuario usuario, DateTime fechaHasta ) : base(metodoDePago, descripcion, monto, tipoDeGasto, usuario)
        {
            FechaDesde = DateTime.Now;
            FechaHasta = fechaHasta;
        }

        public Recurrente(MetodoDePago metodoDePago, string descripcion, double monto, int tipoDeGastoId, int usuarioId, DateTime fechaHasta) : base(metodoDePago, descripcion, monto, tipoDeGastoId, usuarioId)
        {
            FechaDesde = DateTime.Now;
            FechaHasta = fechaHasta;
        }

        protected Recurrente()
        {
        }

        public override double CalcularMontoTotal()
        {
            // Calcular la cantidad total de meses entre las fechas
            int mesesTotales = ((FechaHasta.Year - FechaDesde.Year) * 12) +
                               (FechaHasta.Month - FechaDesde.Month) + 1;

            // Valor de cada cuota
            double valorCuota = Monto / mesesTotales;

            // Calcular cuántos meses faltan desde HOY hasta la fecha de fin
            int mesesRestantes = ((FechaHasta.Year - DateTime.Now.Year) * 12) +
                                 (FechaHasta.Month - DateTime.Now.Month);

            // Si ya venció, el saldo es 0
            if (mesesRestantes < 0) mesesRestantes = 0;

            // Saldo pendiente
            return mesesRestantes * valorCuota;
        }
    }
}
