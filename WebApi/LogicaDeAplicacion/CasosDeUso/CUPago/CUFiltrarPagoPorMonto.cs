using CasosDeUsos.DTOs.EquipoDTO;
using CasosDeUsos.DTOs.PagoDto;
using CasosDeUsos.InterfacesCU.PagoCU;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;


namespace LogicaDeAplicacion.CasosDeUso.CUPago
{
    public class CUFiltrarPagoPorMonto : ICUFiltrarPagoPorMonto
    {
        public IRepositorioPago RepoPago { get; set; }
        public CUFiltrarPagoPorMonto(IRepositorioPago repoPago)
        {
            RepoPago = repoPago;
        }
        public IEnumerable<EquipoListadoDto> Ejecutar(double monto)
        {
            IEnumerable<Equipo> pagosUnicos = RepoPago.FiltrarPagoUnicoPorMonto(monto);


            return PagoMapper.PagoFiltradoMontoToPagoListadoEquipoDto(pagosUnicos);
        }
    }
}
