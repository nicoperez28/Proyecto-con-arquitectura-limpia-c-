using CasosDeUsos.DTOs.AuditoriaDTO;
using CasosDeUsos.DTOs.EquipoDTO;
using LogicaDeNegocio.EntidadesDeNegocio;

namespace LogicaDeAplicacion.Mappers
{
    public class AuditoriaMapper
    {
        public static Auditoria AuditoriaDtoToAuditoria(AuditoriaDto auditoriaDto)
        {
            return new Auditoria(
                                auditoriaDto.Mail, 
                                auditoriaDto.Accion);
        }

        public static IEnumerable<AuditoriaDto>
            AuditoriaToAuditoriaDto(IEnumerable<Auditoria> auditorias)
        {
            List<AuditoriaDto> auditoriaDto = new List<AuditoriaDto>();
            foreach (Auditoria auditoria in auditorias)
            {
                auditoriaDto.Add(new AuditoriaDto()
                {
                    Mail = auditoria.Mail,
                    Accion = auditoria.Accion,
                    Fecha = auditoria.Fecha,
                    NombreTipoDeGasto = auditoria.TipoDeGasto.Nombre,
                    DescripcionTipoDeGasto = auditoria.TipoDeGasto.Descripcion

                });
            }
            return auditoriaDto;

        }
    }
}
