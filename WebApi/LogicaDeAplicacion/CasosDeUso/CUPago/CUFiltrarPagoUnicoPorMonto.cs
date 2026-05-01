using CasosDeUsos.DTOs.EquipoDTO;
using CasosDeUsos.InterfacesCU.PagoCU;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;


namespace LogicaDeAplicacion.CasosDeUso.CUPago
{
    public class CUFiltrarPagoUnicoPorMonto : ICUFiltrarPagoUnicoPorMonto
    {
        public IRepositorioPago RepoPago { get; set; }
        public CUFiltrarPagoUnicoPorMonto(IRepositorioPago repoPago)
        {
            RepoPago = repoPago;
        }
        public IEnumerable<EquipoListadoDto> Ejecutar(double monto)
        {
            IEnumerable<Equipo> equipo = RepoPago.FiltrarPagoUnicoPorMonto(monto);
            return PagoMapper.PagoFiltradoMontoToPagoListadoEquipoDto(equipo);
        }
    }
}
