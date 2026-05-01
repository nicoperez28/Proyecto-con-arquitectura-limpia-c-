using Microsoft.AspNetCore.Mvc;
using MVC.Filters;
using MVC.Models.DTOs.EquipoDto;
using MVC.Models.DTOs.PagoDTO;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics.Arm;

namespace MVC.Controllers
{
    [RolAutorizado("Gerente")]
    public class GerenteController : Controller
    {
        public string UrlBase;

        public GerenteController(IConfiguration configuration)
        {
            UrlBase = configuration.GetValue<string>("UrlBase") + "GerenteApi";
        }

        // GET: GerenteController
        [RolAutorizado("Gerente")]
        public ActionResult ListadoDeEquipos()
        {
            IEnumerable<EquipoListadoDto> equipos = new List<EquipoListadoDto>();
            try
            {
                HttpClient cliente = new HttpClient(); // Crear el cliente HTTP
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                    HttpContext.Session.GetString("Token")); // Agregar el token de autorización
                Task<HttpResponseMessage> tarea = cliente.GetAsync($"{UrlBase}/ListadoEquipos"); // Realizar la solicitud GET
                tarea.Wait();// Esperar a que la tarea se complete
                HttpResponseMessage respuesta = tarea.Result; // Obtener la respuesta
                if (respuesta.IsSuccessStatusCode) // Si la respuesta es exitosa    
                {
                    HttpContent contenido = respuesta.Content; // Obtener el contenido de la respuesta
                    Task<string> contenidoRespuesta = contenido.ReadAsStringAsync(); // Leer el contenido como una cadena
                    contenidoRespuesta.Wait();// Esperar a que la tarea se complete
                    string datos = contenidoRespuesta.Result; //    Obtener los datos como una cadena
                    equipos = JsonConvert.DeserializeObject<IEnumerable<EquipoListadoDto>>(datos);// Deserializar los datos en una colección de objetos ListadoClienteDTO

                }
                else if ((int)respuesta.StatusCode == StatusCodes.Status401Unauthorized) // Si la respuesta es 401 Unauthorized
                {
                    return RedirectToAction("Login", "Home");
                }
                else if ((int)respuesta.StatusCode == StatusCodes.Status403Forbidden)// Si la respuesta es 403 Forbidden
                {
                    return RedirectToAction("Create", "Cliente");
                }
                else
                {
                    HttpContent contenido = respuesta.Content; // Obtener el contenido de la respuesta
                    Task<string> contenidoRespuesta = contenido.ReadAsStringAsync();// Leer el contenido como una cadena
                    contenidoRespuesta.Wait();// Esperar a que la tarea se complete
                    ViewBag.Mensaje = contenidoRespuesta.Result;// Mostrar el mensaje de error en ViewBag
                }


            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Error";
            }
            return View(equipos);
        }

        
        [HttpPost]
        public ActionResult ListadoDeEquipos(double monto)
        {
            IEnumerable<EquipoListadoDto> equipos = new List<EquipoListadoDto>();
            try
            {
                if (monto <= 0)
                {
                    ViewBag.Mensaje = "El monto ingresado no es válido. Debe ser mayor a 0.";
                    return View(equipos);
                }
                HttpClient cliente = new HttpClient(); // Crear el cliente HTTP
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                    HttpContext.Session.GetString("Token")); // Agregar el token de autorización
                Task<HttpResponseMessage> tarea = cliente.GetAsync($"{UrlBase}/ListadoEquiposFiltrado/{monto}"); // Realizar la solicitud GET
                tarea.Wait();// Esperar a que la tarea se complete
                HttpResponseMessage respuesta = tarea.Result; // Obtener la respuesta
                if (respuesta.IsSuccessStatusCode) // Si la respuesta es exitosa    
                {
                    HttpContent contenido = respuesta.Content; // Obtener el contenido de la respuesta
                    Task<string> contenidoRespuesta = contenido.ReadAsStringAsync(); // Leer el contenido como una cadena
                    contenidoRespuesta.Wait();// Esperar a que la tarea se complete
                    string datos = contenidoRespuesta.Result; //    Obtener los datos como una cadena
                    equipos = JsonConvert.DeserializeObject<IEnumerable<EquipoListadoDto>>(datos);// Deserializar los datos en una colección de objetos ListadoClienteDTO

                }
                else if ((int)respuesta.StatusCode == StatusCodes.Status401Unauthorized) // Si la respuesta es 401 Unauthorized
                {
                    return RedirectToAction("Login", "Home");
                }
                else if ((int)respuesta.StatusCode == StatusCodes.Status403Forbidden)// Si la respuesta es 403 Forbidden
                {
                    return RedirectToAction("Create", "Cliente");
                }
                else
                {
                    HttpContent contenido = respuesta.Content; // Obtener el contenido de la respuesta
                    Task<string> contenidoRespuesta = contenido.ReadAsStringAsync();// Leer el contenido como una cadena
                    contenidoRespuesta.Wait();// Esperar a que la tarea se complete
                    ViewBag.Mensaje = contenidoRespuesta.Result;// Mostrar el mensaje de error en ViewBag
                }


            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Error";
            }
            return View(equipos);

        }
    }
}
