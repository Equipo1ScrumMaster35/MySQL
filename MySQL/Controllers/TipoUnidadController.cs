using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySQL.IDataAccess;
using MySQL.Models;
using Microsoft.AspNetCore.Authorization;

namespace MySQL.Controllers
{
    [Authorize(Roles = "1")]
    public class TipoUnidadController : Controller
    {
        TipoUnidadDatos _TipoUnidadDatos = new TipoUnidadDatos();
        public ActionResult ListarTipoUnidad()
        {
            var Lista = _TipoUnidadDatos.Listar();
            return View(Lista);
        }

        public IActionResult CrearTipoUnidad()
        {//Metodo para devolver la vista

            return View();
        }

        [HttpPost]
        public IActionResult CrearTipoUnidad(TipoUnidadModel TipoUnidad)
        {//Metodo que recibe un objeto y lo guarda en la DB
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _TipoUnidadDatos.Guardar(TipoUnidad);

            if (respuesta)
            {
                return RedirectToAction("ListarTipoUnidad");
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult EditarTipoUnidad(int cod_tipounidad)
        {
            var TipoUnidad = _TipoUnidadDatos.Obtener(cod_tipounidad);
            return View(TipoUnidad);
        }

        [HttpPost]
        public IActionResult EditarTipoUnidad(TipoUnidadModel TipoUnidad)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _TipoUnidadDatos.Editar(TipoUnidad);

            if (respuesta)
            {
                return RedirectToAction("ListarTipoUnidad");
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult EliminarTipoUnidad(int cod_tipounidad)
        {
            var TipoUnidad = _TipoUnidadDatos.Obtener(cod_tipounidad);
            return View(TipoUnidad);
        }

        [HttpPost]
        public IActionResult EliminarTipoUnidad(TipoUnidadModel TipoUnidad)
        {
            var respuesta = _TipoUnidadDatos.Eliminar(TipoUnidad);

            if (respuesta)
            {
                return RedirectToAction("ListarTipoUnidad");
            }
            else
            {
                return View();
            }
            return View();
        }
    }
}
