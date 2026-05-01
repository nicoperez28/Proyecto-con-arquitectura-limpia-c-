using CasosDeUsos.DTOs.PagoDto;
using CasosDeUsos.InterfacesCU.PagoCU;
using ExcepcionesPropias.ExcepcionesEntidades;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;

namespace LogicaDeAplicacion.CasosDeUso.CUPago
{
    public class CUBuscarPago : ICUBuscarPago
    {
        IRepositorioPago RepoPago { get; set; }

        public CUBuscarPago(IRepositorioPago repoPago)
        {
            RepoPago = repoPago;
        }

        public PagoDetalleDto Ejecutar(int id)
        {
            Pago pago = RepoPago.GetById(id);
            if (pago != null)
            {
                return PagoMapper.PagoToPagoDetalleDto(pago);
            }
            else
            {
                throw new PagoException("Pago no encontrado");
            }

        }
    }
}
