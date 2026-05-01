using CasosDeUsos.DTOs.UsuarioDTO;

namespace CasosDeUsos.InterfacesCU.UsuarioCU
{
    public interface ICUBuscarUsuarioByMail
    {
       UsuarioDto Ejecutar(string mail);
    }
}
