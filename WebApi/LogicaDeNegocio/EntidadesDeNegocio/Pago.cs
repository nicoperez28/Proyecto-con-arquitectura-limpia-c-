

using ExcepcionesPropias.ExcepcionesEntidades;
using LogicaDeNegocio.InterfacesEntidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogicaDeNegocio.EntidadesDeNegocio
{
    public abstract class Pago : IValidable
    {
        public int Id { get; set; }
        public MetodoDePago MetodoDePago { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }
        public TipoDeGasto TipoDeGasto { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId{ get; set; }
        public int TipoDeGastoId { get; set; }

        public Pago(MetodoDePago metodoDePago, string descripcion, double monto, TipoDeGasto tipoDeGasto, Usuario usuario)
        {
            MetodoDePago = metodoDePago;
            Descripcion = descripcion;
            Monto = monto;
            TipoDeGasto = tipoDeGasto;
            Usuario = usuario;
            Validar();
        }
        public Pago(MetodoDePago metodoDePago, string descripcion, double monto, int tipoDeGastoId, int usuarioId)
        {
            MetodoDePago = metodoDePago;
            Descripcion = descripcion;
            Monto = monto;
            TipoDeGastoId = tipoDeGastoId;
            UsuarioId = usuarioId;
            Validar();
        }

        public Pago()
        {
        }

        public void Validar()
        {
            ValidarDescripcion();
            ValidarMonto();
        }

        private void ValidarDescripcion()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new PagoException("La Descripcion es obligatoria");
            }
        }

        private void ValidarMonto()
        {
            if (Monto < 0)
            {
                throw new PagoException("El monto debe ser mayor a 0");
            }
        }

        public abstract double CalcularMontoTotal();
    }
}
