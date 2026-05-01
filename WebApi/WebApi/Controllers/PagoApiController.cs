using CasosDeUsos.InterfacesCU.PagoCU;
using ExcepcionesPropias.ExcepcionesEntidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoApiController : ControllerBase
    {
        public ICUBuscarPago CUBuscarPago { get; set; }
        public PagoApiController(ICUBuscarPago cUBuscarPago)
        {
            CUBuscarPago = cUBuscarPago;
        }
        // GET: api/<PagoApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PagoApiController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id no es correcto");
                }
                return Ok(CUBuscarPago.Ejecutar(id));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (PagoException ex)
            {
                return NotFound(ex.Message);
            }catch (Exception ex)
            {
                return StatusCode(500,"Error");
            }
        }

        // POST api/<PagoApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PagoApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PagoApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
