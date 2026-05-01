using CasosDeUsos.DTOs.PagoDto;
using CasosDeUsos.InterfacesCU.PagoCU;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;

namespace LogicaDeAplicacion.CasosDeUso.CUPago
{
    public class CUListadoPago : ICUListadoPago
    {
        public IRepositorioPago RepoPago { get; set; }
        public CUListadoPago (IRepositorioPago repoPago)
        {
            RepoPago = repoPago;
        }
        public IEnumerable<PagoListadoDto> Ejecutar()
        {
            IEnumerable<Pago> pagos = RepoPago.GetAll();
            return PagoMapper.PagoListadoToPagoListadoDto(pagos);
        }
    }
}
