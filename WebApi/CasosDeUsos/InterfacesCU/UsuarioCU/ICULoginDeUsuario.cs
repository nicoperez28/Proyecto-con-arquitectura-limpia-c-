using CasosDeUsos.DTOs.UsuarioDTO;


namespace CasosDeUsos.InterfacesCU.UsuarioCU
{
    public interface ICULoginDeUsuario
    {
        UsuarioLogueadoDto Ejecutar(LoginDto loginDto);
    }
}
