using Microsoft.AspNetCore.Mvc;
using MVC.Filters;

namespace MVC.Controllers
{
    [RolAutorizado("Empleado")]
    public class EmpleadoController : Controller
    {
        
    }
}
