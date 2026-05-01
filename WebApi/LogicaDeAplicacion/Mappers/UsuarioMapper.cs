using CasosDeUsos.DTOs.PagoDto;
using CasosDeUsos.DTOs.TipoDeGastoDTO;
using CasosDeUsos.DTOs.UsuarioDTO;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.ValueObject;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaDeAplicacion.Mappers
{
    public class UsuarioMapper
    {
        public static UsuarioLogueadoDto UsuarioToUsuarioLogueadoDto(Usuario usuario)
        {
            if(usuario == null)
            {
                throw new ArgumentNullException("Error en los datos");
            }
            return new UsuarioLogueadoDto()
            {
                Id = usuario.Id,
                Mail = usuario.Mail,
                Rol = usuario.Rol.Tipo,
            };
        }

        public static Usuario AltaUsuarioDtoToUsuario(AltaUsuarioDto altaUsuarioDto)
        {
            return new Usuario(altaUsuarioDto.Nombre,
                                altaUsuarioDto.Apellido,
                                altaUsuarioDto.EquipoId,
                                altaUsuarioDto.RolId,
                                altaUsuarioDto.Contrasenia);
        }

        public static IEnumerable<UsuarioListadoDto> UsuarioListadoToUsuarioListadoDto(IEnumerable<Usuario> usuarios)
        {
            List<UsuarioListadoDto> listadoUsuarios = new List<UsuarioListadoDto>();
            foreach (Usuario usuario in usuarios)
            {
                listadoUsuarios.Add(new UsuarioListadoDto()
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Mail = usuario.Mail,
                });
                
            }
         return listadoUsuarios;
        }
    }
}