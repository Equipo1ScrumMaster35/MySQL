using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MySQL.Controllers
{
    public class CambiarContrasenaController : Controller
    {
        [Authorize(Roles = "1,2")]
        public IActionResult CambiarContrasena()
        {
            return View();
        }
    }
}
