using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySQL.IDataAccess;
using MySQL.Models;

namespace MySQL.Controllers
{
    public class ProyectoController : Controller
    {
        ProyectoDatos _ProyectoDatos = new ProyectoDatos();

        public ActionResult ListarProyecto()
        {
            var Lista = _ProyectoDatos.Listar();
            return View(Lista);
        }

        public IActionResult CrearProyecto()
        {//Metodo para devolver la vista

            return View();
        }

        [HttpPost]
        public IActionResult CrearProyecto(ProyectoModel Proyecto)
        {//Metodo que recibe un objeto y lo guarda en la DB
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _ProyectoDatos.Guardar(Proyecto);

            if (respuesta)
            {
                return RedirectToAction("ListarProyecto");
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult EditarProyecto(int cod_proyecto)
        {
            var Proyecto = _ProyectoDatos.Obtener(cod_proyecto);
            return View(Proyecto);
        }

        [HttpPost]
        public IActionResult EditarProyecto(ProyectoModel Proyecto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _ProyectoDatos.Editar(Proyecto);

            if (respuesta)
            {
                return RedirectToAction("ListarProyecto");
            }
            else
            {
                return View();
            }
            return View();
        }


    }
}
