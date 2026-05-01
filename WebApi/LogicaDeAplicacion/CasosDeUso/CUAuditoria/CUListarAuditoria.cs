
using CasosDeUsos.DTOs.AuditoriaDTO;
using CasosDeUsos.DTOs.PagoDto;
using CasosDeUsos.InterfacesCU.AuditoriaCU;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;

namespace LogicaDeAplicacion.CasosDeUso.CUAuditoria
{
    public class CUListarAuditoria : ICUListarAuditoria
    {
        public IRepositorioAuditoria RepoAuditoria { get; set; }
        public IRepositorioTipoDeGasto RepoTipoDeGasto { get; set; }

        public CUListarAuditoria(IRepositorioAuditoria repoAuditoria, IRepositorioTipoDeGasto repoTipoDeGasto)
        {
            RepoAuditoria = repoAuditoria;
            RepoTipoDeGasto = repoTipoDeGasto;
        }
        public IEnumerable<AuditoriaDto> Ejecutar(int idAuditado)
        {
            IEnumerable<Auditoria> auditoria = RepoAuditoria.ListadoDeAuditoria(idAuditado);
            return AuditoriaMapper.AuditoriaToAuditoriaDto(auditoria);

        }
    }
}
