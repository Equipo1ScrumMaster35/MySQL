using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySQL.IDataAccess;
using MySQL.Models;
using Microsoft.AspNetCore.Authorization;

namespace MySQL.Controllers
{
    [Authorize(Roles ="1")]
    public class CiudadController : Controller
    {
        CiudadDatos _CiudadDatos = new CiudadDatos();

        public ActionResult ListarCiudad()
        {
            var Lista = _CiudadDatos.Listar();
            return View(Lista);
        }
        
        public IActionResult CrearCiudad()
        {//Metodo para devolver la vista
            ViewBag.ListaPais = new SelectList(_CiudadDatos.ListarPais(),"cod_pais","nom_pais");
            return View();
        }

        [HttpPost]
        public IActionResult CrearCiudad(CiudadModel Ciudad)
        {//Metodo que recibe un objeto y lo guarda en la DB

            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _CiudadDatos.Guardar(Ciudad);

            if (respuesta)
            {
                return RedirectToAction("ListarCiudad");
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult EditarCiudad(int cod_ciudad)
        {
            ViewBag.ListaPais = new SelectList(_CiudadDatos.ListarPais(), "cod_pais", "nom_pais");
            var Ciudad = _CiudadDatos.Obtener(cod_ciudad);
            return View(Ciudad);
        }

        [HttpPost]
        public IActionResult EditarCiudad(CiudadModel Ciudad)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _CiudadDatos.Editar(Ciudad);

            if (respuesta)
            {
                return RedirectToAction("ListarCiudad");
            }
            else
            {
                return View();
            }
            return View();
        }
    }
}
