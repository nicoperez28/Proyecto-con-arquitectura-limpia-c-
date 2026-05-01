using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.DTOs.UsuarioDTO;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        public string UrlBase = "";

        public LoginController(ILogger<LoginController> logger, IConfiguration configuration)
        {
            _logger = logger;
            UrlBase = configuration.GetValue<string>("UrlBase") + "LoginApi/Login";
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: LoginController
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                Task<HttpResponseMessage> response = cliente.PostAsJsonAsync(UrlBase, loginDto);
                response.Wait();
                HttpResponseMessage respuesta = response.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    HttpContent contenido = respuesta.Content;
                    Task<string> body = contenido.ReadAsStringAsync();
                    string datos = body.Result;
                    UsuarioLogeadoDto usuarioLogeadoDto = JsonConvert.DeserializeObject<UsuarioLogeadoDto>(datos);
                    if (usuarioLogeadoDto != null)
                    {
                        HttpContext.Session.SetString("Rol", usuarioLogeadoDto.Rol);
                        HttpContext.Session.SetString("Token", usuarioLogeadoDto.Token);
                        HttpContext.Session.SetInt32("Id", usuarioLogeadoDto.Id);

                        string Rol = HttpContext.Session.GetString("Rol");
                        if (Rol == "Administrador")
                        {
                            return RedirectToAction("ListadoDeUsuarios", "Administrador");

                        }
                        return RedirectToAction("PagosPorUsuario", "Usuario", new { id = usuarioLogeadoDto.Id });
                    }
                }
                else
                {
                    HttpContent contenido = respuesta.Content;
                    Task<string> body = contenido.ReadAsStringAsync();
                    string datos = body.Result;
                    ViewBag.Mensaje = datos;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error";
            }
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");

        }
    }
}
          
        
