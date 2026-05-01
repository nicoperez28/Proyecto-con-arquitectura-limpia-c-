using CasosDeUsos.DTOs.AuditoriaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.InterfacesCU.AuditoriaCU
{
    public interface ICUListarAuditoria
    {
        IEnumerable<AuditoriaDto> Ejecutar(int idAuditado);
    }
}
