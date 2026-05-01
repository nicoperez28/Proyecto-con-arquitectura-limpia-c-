using CasosDeUsos.DTOs.UsuarioDTO;
using CasosDeUsos.InterfacesCU.UsuarioCU;
using ExcepcionesPropias.ExcepcionesEntidades;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;

namespace LogicaDeAplicacion.CasosDeUso.CULogin
{
    public class CULoginDeUsuario : ICULoginDeUsuario
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public CULoginDeUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }
        public UsuarioLogueadoDto Ejecutar(LoginDto loginDto)
        {
            Usuario usuario = RepoUsuario.GetByEmail(loginDto.Email, loginDto.Contrasenia);
            if (usuario == null)
            {
                throw new UsuarioException("Mail o contraseña incorrectos");
            }
            return UsuarioMapper.UsuarioToUsuarioLogueadoDto(usuario);
        }
    }
}
