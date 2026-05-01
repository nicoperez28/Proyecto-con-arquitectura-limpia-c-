using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC.Filters
{
    public class RolAutorizadoAttribute : ActionFilterAttribute
    {
        private readonly string[] _rolesPermitidos;

        public RolAutorizadoAttribute(params string[] rolesPermitidos)
        {
            _rolesPermitidos = rolesPermitidos;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var rol = context.HttpContext.Session.GetString("Rol");

            // Si no hay sesión o el rol no está dentro de los permitidos
            if (string.IsNullOrEmpty(rol) || !_rolesPermitidos.Contains(rol))
            {
                // Redirige al Login
                context.Result = new RedirectToActionResult("Login", "Login", null);
            }
        }
    }
}
