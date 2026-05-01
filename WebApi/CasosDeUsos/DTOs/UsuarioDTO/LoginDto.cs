

using System.ComponentModel.DataAnnotations;

namespace CasosDeUsos.DTOs.UsuarioDTO
{
    public class LoginDto
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El correo es obligatorio")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Contrasenia { get; set; }
    }
}
