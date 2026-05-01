using ExcepcionesPropias.ExcepcionesEntidades;
using LogicaDeNegocio.InterfacesEntidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogicaDeNegocio.ValueObject
{
    [ComplexType]
    public record Contrasenia : IValidable, IEquatable<Contrasenia>
    {
        public string Value { get; private set; }

        public Contrasenia(string value)
        {
            Value = value;
            Validar();
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Value) || Value.ToString().Length < 8)
            {
                throw new UsuarioException("Contraseña debe tener almenos 8 caracteres");
            }
        }
    }
}
