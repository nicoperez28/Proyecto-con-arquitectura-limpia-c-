

using ExcepcionesPropias.ExcepcionesEntidades;
using LogicaDeNegocio.InterfacesEntidades;

namespace LogicaDeNegocio.EntidadesDeNegocio
{
    public class TipoDeGasto : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }


        public TipoDeGasto()
        {
        }

        public TipoDeGasto(string nombre, string descripcion, bool estado)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Estado = estado;
            Validar();
        }

        public void Validar()
        {
            ValidarNombre();
            ValidarDescripcion();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new TipoDeGastoException("El nombre es obligatorio");
            }
        }

        private void ValidarDescripcion()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new TipoDeGastoException("La Descripcion es obligatoria");
            }
        }
    }
}
