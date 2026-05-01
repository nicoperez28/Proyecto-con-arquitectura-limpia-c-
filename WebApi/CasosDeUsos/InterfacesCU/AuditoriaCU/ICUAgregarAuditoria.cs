
using CasosDeUsos.DTOs.AuditoriaDTO;

namespace CasosDeUsos.InterfacesCU.AuditoriaCU
{
    public interface ICUAgregarAuditoria
    {
        void Ejecutar(AuditoriaDto auditoriaDto);
    }
}
