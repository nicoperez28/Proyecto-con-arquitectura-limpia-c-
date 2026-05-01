using CasosDeUsos.DTOs.UsuarioDTO;
using CasosDeUsos.InterfacesCU.UsuarioCU;
using ExcepcionesPropias.ExcepcionesEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Autenticacion;
namespace WebApi.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]

    public class LoginApiController : ControllerBase
    {
        public ICULoginDeUsuario CULoginDeUsuario { get; set; }

        public LoginApiController(ICULoginDeUsuario cULoginDeUsuario) {
            CULoginDeUsuario = cULoginDeUsuario;
        }
        /// <summary>
        /// Inicia sesión en el sistema validando las credenciales del usuario y genera un token JWT en caso de éxito.
        /// </summary>
        /// <param name="loginDto">Objeto que contiene las credenciales ingresadas por el usuario (email y contraseña).</param>
        /// <returns>
        /// Devuelve:
        /// - 200 OK con los datos del usuario autenticado y su token.<br/>
        /// - 400 BadRequest si los datos son inválidos o las credenciales son incorrectas.<br/>
        /// - 500 InternalServerError ante un error inesperado.
        /// </returns>

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            try
            {
                if (loginDto == null)
                {
                    return BadRequest("Datos incorrectos");
                }
                UsuarioLogueadoDto usuarioLogueadoDto = CULoginDeUsuario.Ejecutar(loginDto);
                if (usuarioLogueadoDto != null)
                {
                    usuarioLogueadoDto.Token = ManejadorToken.CrearToken(usuarioLogueadoDto);
                }
                return Ok(usuarioLogueadoDto);
            }
            catch (UsuarioException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" );
            }
        }
    }
}