using CasosDeUsos.DTOs.UsuarioDTO;
using CasosDeUsos.InterfacesCU.EquipoCU;
using CasosDeUsos.InterfacesCU.PagoCU;
using ExcepcionesPropias.ExcepcionesEntidades;
using ExcepcionesPropias.ExcepcionesGenericas;
using LogicaDeAplicacion.CasosDeUso.CUPago;
using LogicaDeAplicacion.CasosDeUso.CUUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class GerenteApiController : Controller
    {
        public ICUFiltrarPagoUnicoPorMonto CUFiltrarPagoUnicoPorMonto { get; set; }
        public ICUListarEquipo CUListarEquipo { get; set; }
        public GerenteApiController(ICUFiltrarPagoUnicoPorMonto cUFiltrarPagoUnicoPorMonto, ICUListarEquipo cUListarEquipo) 
        {
            CUFiltrarPagoUnicoPorMonto = cUFiltrarPagoUnicoPorMonto;
            CUListarEquipo = cUListarEquipo;
        }
        /// <summary>
        /// Obtiene el listado completo de equipos registrados en el sistema.
        /// </summary>
        /// <returns>
        /// Devuelve:
        /// - 200 OK con la lista de equipos.<br/>
        /// - 500 InternalServerError si ocurre un error inesperado.
        /// </returns>

        // GET: GerenteController
        [Authorize(Roles = "Gerente")]
        [HttpGet("ListadoEquipos")]
        public IActionResult Get()
        {
            try
            {
                return Ok(CUListarEquipo.Ejecutar());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Obtiene un listado de equipos únicos filtrados por un monto mínimo especificado.
        /// </summary>
        /// <param name="monto">Monto mínimo que deben cumplir los registros para ser incluidos en el resultado.</param>
        /// <returns>
        /// Devuelve:
        /// - 200 OK con los resultados filtrados.<br/>
        /// - 400 BadRequest si el monto es inválido o menor o igual a cero.<br/>
        /// - 404 NotFound si no se encuentran registros que cumplan la condición.<br/>
        /// - 409 Conflict ante un conflicto de negocio.<br/>
        /// - 500 InternalServerError si ocurre un error inesperado.
        /// </returns>

        [Authorize(Roles = "Gerente")]
        [HttpGet("ListadoEquiposFiltrado/{monto}")]
        public IActionResult Get(double monto)
        {
            try
            {
                if (monto <= 0)
                {
                    return BadRequest("Monto no es correcto");
                }
                
                return Ok(CUFiltrarPagoUnicoPorMonto.Ejecutar(monto));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }




    }
    
}