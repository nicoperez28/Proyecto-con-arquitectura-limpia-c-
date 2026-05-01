
namespace MVC.Models.DTOs.UsuarioDTO
{
    public class UsuarioLogeadoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Token { get; set; }
    }
}
