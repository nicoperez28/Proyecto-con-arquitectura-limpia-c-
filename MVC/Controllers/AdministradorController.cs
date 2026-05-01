using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC.Filters;
using MVC.Models.DTOs.AuditoriaDto;
using MVC.Models.DTOs.PagoDTO;
using MVC.Models.DTOs.TipoDeGastoDTO;
using MVC.Models.DTOs.UsuarioDTO;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.Intrinsics.Arm;

namespace MVC.Controllers
{
    [RolAutorizado("Administrador")]
    public class AdministradorController : Controller
    {
        public string UrlBase;

        public AdministradorController(IConfiguration configuration)
        {
            UrlBase = configuration.GetValue<string>("UrlBase") + "AdministradorApi";
        }

        // GET: AdministradorController
        public IActionResult ListadoDeUsuarios ()
        {
            IEnumerable<UsuarioListadoDto> usuarios = new List<UsuarioListadoDto>();
            try
            {
                HttpClient cliente = new HttpClient(); // Crear el cliente HTTP
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                    HttpContext.Session.GetString("Token")); // Agregar el token de autorización
                Task<HttpResponseMessage> tarea = cliente.GetAsync(UrlBase + "/ListadoDeUsuarios"); // Realizar la solicitud GET
                tarea.Wait();// Esperar a que la tarea se complete
                HttpResponseMessage respuesta = tarea.Result; // Obtener la respuesta
                if (respuesta.IsSuccessStatusCode) // Si la respuesta es exitosa    
                {
                    HttpContent contenido = respuesta.Content; // Obtener el contenido de la respuesta
                    Task<string> contenidoRespuesta = contenido.ReadAsStringAsync(); // Leer el contenido como una cadena
                    contenidoRespuesta.Wait();// Esperar a que la tarea se complete
                    string datos = contenidoRespuesta.Result; //    Obtener los datos como una cadena
                    usuarios = JsonConvert.DeserializeObject<IEnumerable<UsuarioListadoDto>>(datos);// Deserializar los datos en una colección de objetos ListadoClienteDTO

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
            return View(usuarios);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, ContraseniaDto contraseniaDto)
        {
            try
            {
                if (id > 0 && ModelState.IsValid)
                {
                    HttpClient cliente = new HttpClient();
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                            "Bearer",
                            HttpContext.Session.GetString("Token"));

                    Task<HttpResponseMessage> tarea = cliente.PutAsJsonAsync(UrlBase + "/" + id, contraseniaDto);
                    tarea.Wait();
                    HttpResponseMessage respuesta = tarea.Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        TempData["Mensaje"] = "La contraseña se cambió con éxito";
                        TempData["Exito"] = true;
                        return RedirectToAction("ListadoDeUsuarios");
                    }
                    else
                    {
                        string datos = respuesta.Content.ReadAsStringAsync().Result;

                        ViewBag.Mensaje = datos;
                        ViewBag.Exito = false;
                    }
                }
                else
                {
                    throw new ArgumentException("Error en los datos");
                }
            }
            catch (ArgumentException ex)
            {
                ViewBag.Mensaje = ex.Message;
                ViewBag.Exito = false;
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Error";
                ViewBag.Exito = false;
            }
            TempData["Mensaje"] = "La contraseña no valida";
            TempData["Exito"] = false;
            return RedirectToAction("Edit");
        }


        public IActionResult ListaDeAuditoria()
        {
            IEnumerable<TipoDeGastoListadoDto> tipoDeGasto = new List<TipoDeGastoListadoDto>();
            try
            {
                HttpClient cliente = new HttpClient(); // Crear el cliente HTTP
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                    HttpContext.Session.GetString("Token")); // Agregar el token de autorización
                Task<HttpResponseMessage> tarea = cliente.GetAsync(UrlBase + "/ListadoTipoDeGasto"); // Realizar la solicitud GET
                tarea.Wait();// Esperar a que la tarea se complete
                HttpResponseMessage respuesta = tarea.Result; // Obtener la respuesta
                if (respuesta.IsSuccessStatusCode) // Si la respuesta es exitosa    
                {
                    HttpContent contenido = respuesta.Content; // Obtener el contenido de la respuesta
                    Task<string> contenidoRespuesta = contenido.ReadAsStringAsync(); // Leer el contenido como una cadena
                    contenidoRespuesta.Wait();// Esperar a que la tarea se complete
                    string datos = contenidoRespuesta.Result; //    Obtener los datos como una cadena
                    tipoDeGasto = JsonConvert.DeserializeObject<IEnumerable<TipoDeGastoListadoDto>>(datos);// Deserializar los datos en una colección de objetos ListadoClienteDTO

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
            ViewBag.TiposDeGasto = tipoDeGasto;
            return View(new List<AuditoriaDto>());
        }

        [HttpPost]
        public IActionResult ListaDeAuditoria(int TipoDeGastoId)
        {
            IEnumerable<AuditoriaDto> auditorias = new List<AuditoriaDto>();

            try
            {
                // 🔹 Cargar auditorías filtradas
                HttpClient cliente = new HttpClient();
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                    HttpContext.Session.GetString("Token"));

                Task<HttpResponseMessage> tarea = cliente.GetAsync($"{UrlBase}/ListadoDeAuditoria/{TipoDeGastoId}");
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadAsStringAsync().Result;
                    auditorias = JsonConvert.DeserializeObject<IEnumerable<AuditoriaDto>>(datos);
                }
                else if ((int)respuesta.StatusCode == StatusCodes.Status401Unauthorized)
                {
                    return RedirectToAction("Login", "Home");
                }
                else if ((int)respuesta.StatusCode == StatusCodes.Status403Forbidden)
                {
                    return RedirectToAction("Create", "Cliente");
                }
                else
                {
                    ViewBag.Mensaje = respuesta.Content.ReadAsStringAsync().Result;
                }

                // 🔹 Cargar tipos de gasto para el select
                Task<HttpResponseMessage> tareaTipos = cliente.GetAsync($"{UrlBase}/ListadoTipoDeGasto");
                tareaTipos.Wait();
                var respuestaTipos = tareaTipos.Result;

                if (respuestaTipos.IsSuccessStatusCode)
                {
                    var datosTipos = respuestaTipos.Content.ReadAsStringAsync().Result;
                    ViewBag.TiposDeGasto = JsonConvert.DeserializeObject<IEnumerable<TipoDeGastoListadoDto>>(datosTipos);
                }
                else
                {
                    ViewBag.TiposDeGasto = new List<TipoDeGastoListadoDto>();
                }
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Error";
                ViewBag.TiposDeGasto = new List<TipoDeGastoListadoDto>();
            }

            // 🔹 Para mantener seleccionado el valor filtrado
            ViewBag.TipoSeleccionado = TipoDeGastoId;

            return View(auditorias);
        }
    }
}
