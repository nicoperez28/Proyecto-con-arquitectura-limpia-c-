

using CasosDeUsos.DTOs.AuditoriaDTO;
using CasosDeUsos.DTOs.PagoDto;
using CasosDeUsos.InterfacesCU.PagoCU;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;

namespace LogicaDeAplicacion.CasosDeUso.CUPago
{
    public class CUAgregarPago: ICUAgregarPago
    {
        public IRepositorioPago RepoPago { get; set; }

        public CUAgregarPago(IRepositorioPago repoPago)
        {
            RepoPago = repoPago;
        }
        public void Ejecutar(PagoDto pagoDto)
        {
                Pago pago = PagoMapper.PagoDtoToPago(pagoDto);
                RepoPago.Add(pago);
        }
        
    }
}
