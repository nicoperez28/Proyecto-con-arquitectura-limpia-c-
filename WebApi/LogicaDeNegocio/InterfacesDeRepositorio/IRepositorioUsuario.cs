
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.ValueObject;

namespace LogicaDeNegocio.InterfacesDeRepositorio
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        Usuario GetByEmail(string email, string contrasenia);
        Usuario BuscarUsuarioByMail(string mail);
        string GenerarEmail(string nombre, string apellido);
        string LimpiarTexto(string texto);
        void ModificarContrasenia(int id, Usuario usuario);
    }
}
