using CasosDeUsos.DTOs.PagoDto;
using CasosDeUsos.DTOs.UsuarioDTO;
using CasosDeUsos.InterfacesCU.UsuarioCU;
using ExcepcionesPropias.ExcepcionesEntidades;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;


namespace LogicaDeAplicacion.CasosDeUso.CUUsuario
{
    public class CUBuscarUsuarioByMail //: ICUBuscarUsuarioByMail
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

         public CUBuscarUsuarioByMail(IRepositorioUsuario repoUsuario)
         {
             RepoUsuario = repoUsuario;
         }
         /*public UsuarioDto Ejecutar(string mail)
         {
            Usuario usuario = RepoUsuario.BuscarUsuarioByMail(mail);
            
             if (usuario != null)
             {
                 return UsuarioMapper.UsuarioToUsuarioLogueadoDto(usuario);
             }
             else
             {
                 throw new UsuarioException("Mail incorrecto");
             }
         }*/
    }
}
