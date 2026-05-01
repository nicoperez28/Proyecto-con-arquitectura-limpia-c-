using CasosDeUsos.DTOs.UsuarioDTO;
using CasosDeUsos.InterfacesCU.AuditoriaCU;
using CasosDeUsos.InterfacesCU.TipoDeGastoCU;
using CasosDeUsos.InterfacesCU.UsuarioCU;
using ExcepcionesPropias.ExcepcionesEntidades;
using ExcepcionesPropias.ExcepcionesGenericas;
using LogicaDeAplicacion.CasosDeUso.CUEquipo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AdministradorApiController : Controller
    {
        public ICUModificarContrasenia CUModificarContrasenia { get; set; }
        public ICUListarUsuarios CUListarUsuarios { get; set; }
        public ICUListarAuditoria CUListarAuditoria { get; set; }
        public ICUListadoTipoDeGasto CUListadoTipoDeGasto { get; set; }

        public AdministradorApiController (ICUModificarContrasenia cUModificarContrasenia, 
                                            ICUListarUsuarios cUListarUsuarios, ICUListarAuditoria cUListarAuditoria,
                                            ICUListadoTipoDeGasto cUListadoTipoDeGasto)
        {
            CUModificarContrasenia = cUModificarContrasenia;
            CUListarUsuarios = cUListarUsuarios;
            CUListarAuditoria = cUListarAuditoria; 
            CUListadoTipoDeGasto = cUListadoTipoDeGasto;
        }


        /// <summary>
        /// Modifica la contraseña de un usuario administrador identificado por su ID.
        /// </summary>
        /// <param name="id">ID del usuario cuya contraseña se desea modificar.</param>
        /// <param name="contraseniaDto">Objeto que contiene la nueva contraseña y su confirmación.</param>
        /// <returns>
        /// Devuelve:
        /// - 200 OK si la contraseña se modificó correctamente.<br/>
        /// - 400 BadRequest si los datos son inválidos.<br/>
        /// - 404 NotFound si el usuario no existe.<br/>
        /// - 409 Conflict si existe un conflicto de negocio.<br/>
        /// - 500 InternalServerError ante un error inesperado.
        /// </returns>

        // GET: AdministradorApiController/Edit/5
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody]ContraseniaDto contraseniaDto)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Id no es correcto");
                }
                if (contraseniaDto == null)
                {
                    return BadRequest("Datos incorrectos");
                }
                CUModificarContrasenia.Ejecutar(id, contraseniaDto);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UsuarioException ex)
            {
                return BadRequest (ex.Message);
            }
            catch(ConflictException ex)
            {
                return Conflict (ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound (ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        /// <summary>
        /// Obtiene un listado completo de todos los usuarios registrados en el sistema.
        /// </summary>
        /// <returns>
        /// Devuelve:
        /// - 200 OK con la lista de usuarios.<br/>
        /// - 500 InternalServerError ante un error inesperado.
        /// </returns>

        [Authorize(Roles = "Administrador")]
        [HttpGet("ListadoDeUsuarios")]
        public IActionResult Get()
        {
            try
            {
                return Ok(CUListarUsuarios.Ejecutar());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Retorna un listado con todos los tipos de gasto disponibles en el sistema.
        /// Solo puede ser accedido por usuarios con rol de Administrador.
        /// </summary>
        /// <returns>
        /// 200 OK: Devuelve la lista de tipos de gasto.  
        /// 500 InternalServerError: Ocurre cuando sucede un error inesperado durante la ejecución.
        /// </returns>
        [Authorize(Roles = "Administrador")]
        [HttpGet("ListadoTipoDeGasto")]
        public IActionResult ListadoTipoDeGasto()
        {
            try
            {
                return Ok(CUListadoTipoDeGasto.Ejecutar());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el historial de auditoría asociado a un Tipo de gasto identificado por su ID.
        /// </summary>
        /// <param name="id">ID del Tipo de gasto del cual se desea obtener la auditoría.</param>
        /// <returns>
        /// Devuelve:
        /// - 200 OK con el historial de auditoría.<br/>
        /// - 400 BadRequest si el ID es inválido.<br/>
        /// - 500 InternalServerError ante un error inesperado.
        /// </returns>

        [Authorize(Roles = "Administrador")]
        [HttpGet("ListadoDeAuditoria/{id}")]
        public IActionResult ObtenerAuditoria(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Datos Incorrectos");
                }
                return Ok(CUListarAuditoria.Ejecutar(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
