using Microsoft.AspNetCore.Mvc;
using MVC.Filters;
using MVC.Models.DTOs.PagoDTO;
using MVC.Models.DTOs.TipoDeGastoDTO;
using Newtonsoft.Json;
using System.Net.Http.Headers;



namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        public string UrlBase;

        public UsuarioController(IConfiguration configuration)
        {
            UrlBase = configuration.GetValue<string>("UrlBase") + "UsuarioApi";
        }
        [RolAutorizado("Empleado", "Gerente")]
        public ActionResult PagosPorUsuario()
        {
            IEnumerable<PagoListadoDto> pagos = new List<PagoListadoDto>();
            try
            {
                HttpClient cliente = new HttpClient(); // Crear el cliente HTTP
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                    HttpContext.Session.GetString("Token")); // Agregar el token de autorización
                Task<HttpResponseMessage> tarea = cliente.GetAsync($"{UrlBase}/FiltrarPagoPorMail"); // Realizar la solicitud GET
                tarea.Wait();// Esperar a que la tarea se complete
                HttpResponseMessage respuesta = tarea.Result; // Obtener la respuesta
                if (respuesta.IsSuccessStatusCode) // Si la respuesta es exitosa    
                {
                    HttpContent contenido = respuesta.Content; // Obtener el contenido de la respuesta
                    Task<string> contenidoRespuesta = contenido.ReadAsStringAsync(); // Leer el contenido como una cadena
                    contenidoRespuesta.Wait();// Esperar a que la tarea se complete
                    string datos = contenidoRespuesta.Result; //    Obtener los datos como una cadena
                    pagos = JsonConvert.DeserializeObject<IEnumerable<PagoListadoDto>>(datos);// Deserializar los datos en una colección de objetos ListadoClienteDTO

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
            return View(pagos);
        }



        // GET: UsuarioController/Create
        [RolAutorizado("Administrador" ,"Gerente" ,"Empleado")]
        public ActionResult AltaDePago()
        {
            PagoDto pagoDto = new PagoDto();
            try
            {
                HttpClient cliente = new HttpClient(); // Crear el cliente HTTP
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                    HttpContext.Session.GetString("Token")); // Agregar el token de autorización
                Task<HttpResponseMessage> tarea = cliente.GetAsync($"{UrlBase}/ListaDeGastos"); // Realizar la solicitud GET
                tarea.Wait();// Esperar a que la tarea se complete
                HttpResponseMessage respuesta = tarea.Result; // Obtener la respuesta
                if (respuesta.IsSuccessStatusCode) // Si la respuesta es exitosa    
                {
                    HttpContent contenido = respuesta.Content; // Obtener el contenido de la respuesta
                    Task<string> contenidoRespuesta = contenido.ReadAsStringAsync(); // Leer el contenido como una cadena
                    contenidoRespuesta.Wait();// Esperar a que la tarea se complete
                    string datos = contenidoRespuesta.Result; //    Obtener los datos como una cadena
                    pagoDto.tiposDeGasto = JsonConvert.DeserializeObject<IEnumerable<TipoDeGastoListadoDto>>(datos);// Deserializar los datos Se carga la lista 

                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                    HttpContext.Session.GetString("Token")); // Agregar el token de autorización
                    Task<HttpResponseMessage> tarea1 = cliente.GetAsync($"{UrlBase}/MetodosDePago"); // Realizar la solicitud GET
                    tarea1.Wait();// Esperar a que la tarea se complete
                    HttpResponseMessage respuesta1 = tarea1.Result; // Obtener la respuesta
                    if (respuesta.IsSuccessStatusCode) // Si la respuesta es exitosa    
                    {
                        HttpContent contenido1 = respuesta1.Content; // Obtener el contenido de la respuesta
                        Task<string> contenidoRespuesta1 = contenido1.ReadAsStringAsync(); // Leer el contenido como una cadena
                        contenidoRespuesta1.Wait();// Esperar a que la tarea se complete
                        string datos1 = contenidoRespuesta1.Result; //    Obtener los datos como una cadena
                        pagoDto.MetodosDePago = JsonConvert.DeserializeObject<IEnumerable<string>>(datos1);
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
                        HttpContent contenido1 = respuesta1.Content; // Obtener el contenido de la respuesta
                        Task<string> contenidoRespuesta1 = contenido1.ReadAsStringAsync();// Leer el contenido como una cadena
                        contenidoRespuesta1.Wait();// Esperar a que la tarea se complete
                        ViewBag.Mensaje = contenidoRespuesta1.Result;// Mostrar el mensaje de error en ViewBag
                    }


                }
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Error";
            }
            return View(pagoDto);
        }

        [HttpPost]
        [RolAutorizado("Administrador", "Gerente", "Empleado")]
        public ActionResult AltaDePago(PagoDto pagoDto, int idLogueado)
        {
            try
            {
                HttpClient cliente = new HttpClient(); // Crear el cliente HTTP
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                    HttpContext.Session.GetString("Token")); // Agregar el token de autorización
                Task<HttpResponseMessage> tarea = cliente.PostAsJsonAsync($"{UrlBase}/AltaDePago", pagoDto); // Realizar la solicitud GET
                tarea.Wait();// Esperar a que la tarea se complete
                HttpResponseMessage respuesta = tarea.Result; // Obtener la respuesta
                if (respuesta.IsSuccessStatusCode)
                {
                    TempData["MensajeExito"] = "El pago fue creado con éxito.";

                    if (HttpContext.Session.GetString("Rol") == "Administrador")
                    {
                        return RedirectToAction("ListadoDeUsuarios", "Administrador");
                    }
                    return RedirectToAction("PagosPorUsuario", "Usuario");
                }
                else if ((int)respuesta.StatusCode == StatusCodes.Status400BadRequest ||
                    (int)respuesta.StatusCode == StatusCodes.Status409Conflict)
                {
                    HttpContent contenido = respuesta.Content;
                    Task<string> body = contenido.ReadAsStringAsync();
                    body.Wait();
                    string datos = body.Result;
                    ViewBag.Mensaje = datos;
                }


            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Error";
            }
            return View(pagoDto);
        }
    }
}
