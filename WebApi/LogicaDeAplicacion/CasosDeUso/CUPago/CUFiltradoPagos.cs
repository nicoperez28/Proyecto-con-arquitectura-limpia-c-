using CasosDeUsos.DTOs.PagoDto;
using CasosDeUsos.InterfacesCU.PagoCU;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;

namespace LogicaDeAplicacion.CasosDeUso.CUPago
{
    public class CUFiltradoPagos : ICUFiltradoPagos
    {
        public IRepositorioPago RepoPago { get; set; }
        public CUFiltradoPagos(IRepositorioPago repoPago)
        {
            RepoPago = repoPago;
        }
        public IEnumerable<PagoFiltradoDto> Ejecutar(DateTime fechaFiltro)
        {
            IEnumerable<Pago> pagosUnicos = RepoPago.GetAllPagoUnico(fechaFiltro);
            IEnumerable<Pago> pagosRecurrentes = RepoPago.GetAllRecurrente(fechaFiltro);

            return PagoMapper.PagoFiltradoToPagoFiltradoDto(pagosUnicos, pagosRecurrentes);
        }

    }
}
