using CasosDeUsos.DTOs.PagoDto;
using CasosDeUsos.DTOs.UsuarioDTO;
using CasosDeUsos.InterfacesCU.UsuarioCU;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;

namespace LogicaDeAplicacion.CasosDeUso.CUUsuario
{
    public class CUAgregarUsuario : ICUAgregarUsuario
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public CUAgregarUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }
        public void Ejecutar(AltaUsuarioDto altaUsuarioDto)
        {
            Usuario usuario = UsuarioMapper.AltaUsuarioDtoToUsuario(altaUsuarioDto);
            RepoUsuario.Add(usuario);
        }
    }
}
