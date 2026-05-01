using CasosDeUsos.DTOs.EquipoDTO;
using CasosDeUsos.DTOs.Rol;
namespace CasosDeUsos.DTOs.UsuarioDTO
{
    public class AltaUsuarioDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int EquipoId { get; set; }
        public int RolId { get; set; }
        public string Contrasenia { get; set; }
        public IEnumerable<EquipoListadoDto> equipos { get; set; } = new List<EquipoListadoDto>();
        public IEnumerable<RolListadoDto> roles { get; set; } = new List<RolListadoDto>();
    }
}
