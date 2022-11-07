using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySQL.IDataAccess;
using MySQL.Models;
using Microsoft.AspNetCore.Authorization;


namespace MySQL.Controllers
{
    [Authorize(Roles ="1")]
    public class IntegranteController : Controller
    {
        IntegranteDatos _IntegranteDatos = new IntegranteDatos();

        public ActionResult ListarIntegrante()
        {
            var Lista = _IntegranteDatos.Listar();
            return View(Lista);
        }

        public IActionResult CrearIntegrante()
        {//Metodo para devolver la vista
            ViewBag.ListaRol = new SelectList(_IntegranteDatos.ListarRol(), "cod_rol", "rol_integrante");
            ViewBag.ListaCiudad = new SelectList(_IntegranteDatos.ListarCiudad(), "cod_ciudad", "nom_ciudad");
            return View();
        }

        [HttpPost]
        public IActionResult CrearIntegrante(IntegranteModel Integrante)
        {//Metodo que recibe un objeto y lo guarda en la DB

            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _IntegranteDatos.Guardar(Integrante);

            if (respuesta)
            {
                return RedirectToAction("ListarIntegrante");
            }
            else
            {
                return View();
            }
            return View();
        }
        //Arreglar el metodo de editar, no funciona bien 
        public IActionResult EditarIntegrante(int doc_integrante)
        {
            ViewBag.ListaRol = new SelectList(_IntegranteDatos.ListarRol(), "cod_rol", "rol_integrante");
            ViewBag.ListaCiudad = new SelectList(_IntegranteDatos.ListarCiudad(), "cod_ciudad", "nom_ciudad");
            var Integrante = _IntegranteDatos.Obtener(doc_integrante);
            return View(Integrante);
        }

        [HttpPost]
        public IActionResult EditarIntegrante(IntegranteModel Integrante)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _IntegranteDatos.Editar(Integrante);

            if (respuesta)
            {
                return RedirectToAction("ListarIntegrante");
            }
            else
            {
                return View();
            }
            return View();
        }
    }
}
