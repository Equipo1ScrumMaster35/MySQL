using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySQL.IDataAccess;
using MySQL.Models;

namespace MySQL.Controllers
{
    public class PaisController : Controller
    {
        PaisDatos _PaisDatos = new PaisDatos();

        public ActionResult ListarPais()
        {
            var Lista = _PaisDatos.Listar();
            return View(Lista);
        }

        public IActionResult CrearPais()
        {//Metodo para devolver la vista

            return View();
        }

        [HttpPost]
        public IActionResult CrearPais(PaisModel Pais)
        {//Metodo que recibe un objeto y lo guarda en la DB
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _PaisDatos.Guardar(Pais);

            if (respuesta)
            {
                return RedirectToAction("ListarPais");
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult EditarPais(int cod_pais)
        {
            var Pais = _PaisDatos.Obtener(cod_pais);
            return View(Pais);
        }

        [HttpPost]
        public IActionResult EditarPais(PaisModel Pais)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _PaisDatos.Editar(Pais);

            if (respuesta)
            {
                return RedirectToAction("ListarPais");
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult EliminarPais(int cod_pais)
        {
            var Pais = _PaisDatos.Obtener(cod_pais);
            return View(Pais);
        }

        [HttpPost]
        public IActionResult EliminarPais(PaisModel Pais)
        {
            var respuesta = _PaisDatos.EliminarPais(Pais);

            if (respuesta)
            {
                return RedirectToAction("ListarPais");
            }
            else
            {
                return View();
            }
            return View();
        }

    }
}
