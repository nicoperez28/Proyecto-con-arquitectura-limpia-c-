using CasosDeUsos.DTOs.PagoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.InterfacesCU.PagoCU
{
    public interface ICUGetPagosUsuarioByMail
    {
        IEnumerable<PagoListadoDto> Ejecutar(string mail);
    }
}
