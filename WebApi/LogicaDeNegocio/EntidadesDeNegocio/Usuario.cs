
using ExcepcionesPropias.ExcepcionesEntidades;
using LogicaDeNegocio.InterfacesEntidades;
using LogicaDeNegocio.ValueObject;

namespace LogicaDeNegocio.EntidadesDeNegocio
{
    public class Usuario : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public Equipo Equipo { get; set; }
        public int EquipoId { get; set; }
        public Rol Rol { get; set; }
        public int RolId { get; set; }
        public Contrasenia Contrasenia { get; set; }

        public Usuario()
        {
        }

        public Usuario(string nombre, string apellido, string mail, string rol, string contrasenia)
        {
            Nombre = nombre;
            Apellido = apellido;
            Mail = null;
            Rol = new Rol(rol);
            Contrasenia = new Contrasenia (contrasenia);
            Validar();
        }

        public Usuario(string nombre, string apellido, int equipoId, int rolId, string contrasenia)
        {
            Nombre = nombre;
            Apellido = apellido;
            Mail = null;
            EquipoId = equipoId;
            RolId = rolId;
            Contrasenia = new Contrasenia(contrasenia);
            Validar();
        }

        public void Validar()
        {
            ValidarNombre();
            ValidarApellido();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new UsuarioException("El nombre es obligatorio");
            }
        }

        private void ValidarApellido()
        {
            if (string.IsNullOrEmpty(Apellido))
            {
                throw new UsuarioException("El apellido es obligatorio");
            }
        }
    }
}
