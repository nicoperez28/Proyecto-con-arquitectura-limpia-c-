
using ExcepcionesPropias.ExcepcionesEntidades;
using ExcepcionesPropias.ExcepcionesGenericas;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;
using LogicaDeNegocio.ValueObject;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

namespace LogicaDeAccesoADatos.Repositorios
{
    public class RepositorioUsuarioEF : IRepositorioUsuario
    {
        public Contexto Contexto { get; set; }
        private readonly Random _random = new Random();
        public RepositorioUsuarioEF(Contexto contexto)
        {
            Contexto = contexto;
        }
        public void Add(Usuario item)
        {
            Usuario usuario = new Usuario
            {
                Nombre = item.Nombre,
                Apellido = item.Apellido,
                EquipoId = item.EquipoId,
                Mail = GenerarEmail(item.Nombre, item.Apellido),
                RolId = item.RolId,
                Contrasenia = item.Contrasenia,
            };
            if (usuario != null)
            {
                Contexto.Usuarios.Add(usuario);
                Contexto.SaveChanges();
            }
            else
            {
                throw new UsuarioException("Datos Invalidos");
            }

        }
        public string GenerarEmail(string nombre, string apellido)
        {
            string nombreLimpio = LimpiarTexto(nombre.ToLower());
            string apellidoLimpio = LimpiarTexto(apellido.ToLower());

            string parteNombre = nombreLimpio.Length < 3 ? nombreLimpio : nombreLimpio.Substring(0, 3);
            string parteApellido = apellidoLimpio.Length < 3 ? apellidoLimpio : apellidoLimpio.Substring(0, 3);

            string baseEmail = parteNombre + parteApellido;
            string emailFinal = baseEmail + "@laEmpresa.com";

            while (Contexto.ExisteEmail(emailFinal))
            {
                int numero = _random.Next(1000, 9999);
                emailFinal = baseEmail + numero + "@laEmpresa.com";
            }

            return emailFinal;
        }

        public string LimpiarTexto(string texto)
        {
            string textoNormalizado = texto.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in textoNormalizado)
            {
                var categoria = CharUnicodeInfo.GetUnicodeCategory(c);
                if (categoria != UnicodeCategory.NonSpacingMark)
                {
                    if (c == 'ñ') sb.Append('n');
                    else if (c == 'Ñ') sb.Append('n');
                    else sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return Contexto.Usuarios;
        }

        public Usuario GetById(int id)
        {
            return Contexto.Usuarios
                .Where(x => x.Id == id)
                .SingleOrDefault();
        }

        public Usuario GetByEmail(string mail, string contrasenia)
        {
            return Contexto.Usuarios
                .Include(u => u.Rol)
                .Where(u => u.Mail == mail && u.Contrasenia.Value == contrasenia)
                .SingleOrDefault();
        }

        public Usuario BuscarUsuarioByMail(string mail)
        {
            return Contexto.Usuarios
            .Include(u => u.Rol)
                .Where(u => u.Mail == mail)
                .SingleOrDefault();
        }

        public void ModificarContrasenia(int id, Usuario usuario)
        {
                Contexto.SaveChanges();  
        }
    }
}