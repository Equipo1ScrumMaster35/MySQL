using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySQL.IDataAccess;
using MySQL.Models;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace MySQL.Controllers
{
    public class InicioSesionController : Controller
    {   
        InicioSesionDatos _Inicio = new InicioSesionDatos();
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(IntegranteValidacionModel Inte)
        {
            var Integrante = _Inicio.ValidarIntegrante(Inte);

            if(Integrante.estado_integrante != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Integrante.doc_integrante),
                    new Claim("Estado",Integrante.estado_integrante)
                };

                foreach(char rol in Integrante.fk_codrol)
                {
                    claims.Add(new Claim(ClaimTypes.Role, Convert.ToString(rol)));
                }

                var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario o contraseña invalidos";
                return View();
            }
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "InicioSesion");
    
        }
    }
}
