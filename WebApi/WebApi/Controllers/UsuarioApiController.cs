using CasosDeUsos.DTOs.PagoDto;
using CasosDeUsos.InterfacesCU.MetodoDePagoCU;
using CasosDeUsos.InterfacesCU.PagoCU;
using CasosDeUsos.InterfacesCU.TipoDeGastoCU;
using ExcepcionesPropias.ExcepcionesEntidades;
using ExcepcionesPropias.ExcepcionesGenericas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsuarioApiController : Controller
    {
        public ICUGetPagosUsuarioByMail CUGetPagosUsuarioById { get; set; }
        public ICUAgregarPago CUAgregarPago { get; set; }
        public ICUListadoTipoDeGasto CUListadoTipoDeGasto { get; set; }
        public ICUObtenerEnum CUObtenerEnum { get; set; }


        public UsuarioApiController(ICUGetPagosUsuarioByMail cUGetPagosUsuarioById, ICUAgregarPago cUAgregarPago,
                ICUListadoTipoDeGasto cUListadoTipoDeGasto, ICUObtenerEnum cUObtenerEnum)
        {
            CUGetPagosUsuarioById = cUGetPagosUsuarioById;
            CUAgregarPago = cUAgregarPago;
            CUListadoTipoDeGasto = cUListadoTipoDeGasto;
            CUObtenerEnum = cUObtenerEnum;
        }
        /// <summary>
        /// Obtiene los pagos asociados al usuario autenticado mediante su correo extraído del token.
        /// </summary>
        /// <returns>
        /// Devuelve:
        /// - 200 OK con los pagos del usuario.<br/>
        /// - 400 BadRequest si el correo no puede obtenerse o es inválido.<br/>
        /// - 404 NotFound si no se encuentran pagos asociados.<br/>
        /// - 500 InternalServerError si ocurre un error inesperado.
        /// </returns>
        [Authorize(Roles = "Empleado, Gerente")]
        [HttpGet("FiltrarPagoPorMail")]
        public IActionResult Get()
        {
            try
            {
                string mail = User.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email)?.Value ?? User.FindFirst(ClaimTypes.Email)?.Value;
                return Ok(CUGetPagosUsuarioById.Ejecutar(mail));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UsuarioException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }
        /// <summary>
        /// Obtiene el listado completo de tipos de gastos disponibles en el sistema.
        /// </summary>
        /// <returns>
        /// Devuelve:
        /// - 200 OK con la lista de tipos de gasto.<br/>
        /// - 500 InternalServerError si ocurre un error inesperado.
        /// </returns>
        [HttpGet("ListaDeGastos")]
        public IActionResult ListaDeGastos()
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
        /// Obtiene la lista de métodos de pago disponibles en el sistema mediante un enum.
        /// </summary>
        /// <returns>
        /// Devuelve:
        /// - 200 OK con los métodos de pago.<br/>
        /// - 500 InternalServerError si ocurre un error inesperado.
        /// </returns>

        [HttpGet("MetodosDePago")]
        public IActionResult MetodosDePago()
        {
            try
            {
                return Ok(CUObtenerEnum.Ejecutar());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Registra un nuevo pago realizado por el usuario autenticado.
        /// </summary>
        /// <param name="pagoDto">Objeto que contiene los datos del pago que se desea registrar.</param>
        /// <returns>
        /// Devuelve:
        /// - 200 OK si el pago se registró correctamente.<br/>
        /// - 400 BadRequest si los datos son inválidos o existe un error de negocio.<br/>
        /// - 409 Conflict si ocurre un conflicto en la creación del pago.<br/>
        /// - 500 InternalServerError ante un error inesperado.
        /// </returns>
        // POST api/<ClienteWebAPIController>
        [Authorize(Roles = "Empleado, Gerente, Administrador")]
        [HttpPost("AltaDePago")]
        public IActionResult Create([FromBody] PagoDto pagoDto)
        {
            try
            {
                if (pagoDto == null)
                {
                    return BadRequest("Datos incorrectos");
                }
                string idText = User.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Name)?.
                                Value ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                int.TryParse(idText, out int id);
                pagoDto.UsuarioId = id;
                CUAgregarPago.Ejecutar(pagoDto);
                return Ok();
            }
            catch (PagoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }

        }


    }
}
