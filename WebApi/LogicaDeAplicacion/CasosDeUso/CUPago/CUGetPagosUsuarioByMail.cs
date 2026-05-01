using CasosDeUsos.DTOs.PagoDto;
using CasosDeUsos.InterfacesCU.PagoCU;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.CUPago
{
    public class CUGetPagosUsuarioByMail : ICUGetPagosUsuarioByMail
    {
        public IRepositorioPago RepoPago {  get; set; }
        public CUGetPagosUsuarioByMail(IRepositorioPago repoPago)
        {
            RepoPago = repoPago;
        }
        public IEnumerable<PagoListadoDto> Ejecutar(string mail)
        {
            IEnumerable<Pago> pagos = RepoPago.FiltrarPagoPorMail(mail);
            return PagoMapper.PagoListadoToPagoListadoDto(pagos);
        }
    }
}
