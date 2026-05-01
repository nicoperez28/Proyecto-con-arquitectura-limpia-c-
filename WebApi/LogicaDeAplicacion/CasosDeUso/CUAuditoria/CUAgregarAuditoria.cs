using CasosDeUsos.DTOs.AuditoriaDTO;
using CasosDeUsos.InterfacesCU.AuditoriaCU;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;
namespace LogicaDeAplicacion.CasosDeUso.CUAuditoria
{
    public class CUAgregarAuditoria : ICUAgregarAuditoria
    {
        public IRepositorioAuditoria RepoAuditoria { get; set; }

        public CUAgregarAuditoria(IRepositorioAuditoria repoAuditoria)
        {
            RepoAuditoria = repoAuditoria;
        }
        public void Ejecutar(AuditoriaDto auditoriaDto)
        {
            Auditoria auditoria = AuditoriaMapper.AuditoriaDtoToAuditoria(auditoriaDto);
            RepoAuditoria.Add(auditoria);
        }
    }
}
