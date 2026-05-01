

namespace LogicaDeNegocio.EntidadesDeNegocio
{
    public class PagoUnico : Pago
    {
        public DateTime FechaDePago { get; set; }
        public string NumeroDeRecibo { get; set; }
        public PagoUnico(MetodoDePago metodoDePago, string descripcion, double monto, TipoDeGasto tipoDeGasto, Usuario usuario) : base(metodoDePago, descripcion, monto, tipoDeGasto, usuario)
        {
            FechaDePago = DateTime.Now;
            NumeroDeRecibo = GenerarNumeroRecibo();
        }
        public PagoUnico(MetodoDePago metodoDePago, string descripcion, double monto, int tipoDeGastoId, int usuarioId) : base(metodoDePago, descripcion, monto, tipoDeGastoId, usuarioId)
        {
            FechaDePago = DateTime.Now;
            NumeroDeRecibo = GenerarNumeroRecibo();
        }
        protected PagoUnico()
        {
        }
        public override double CalcularMontoTotal()
        {
            return 0;
        }
        public static string GenerarNumeroRecibo()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }
    }
}
