using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySQL.IDataAccess;
using MySQL.Models;
using Microsoft.AspNetCore.Authorization;

namespace MySQL.Controllers
{
    [Authorize(Roles = "1")]
    public class TipoCampanaController : Controller
    {
        TipoCampanaDatos _TipoCampanaDatos = new TipoCampanaDatos();
        public ActionResult ListarTipoCampana()
        {
            var Lista = _TipoCampanaDatos.Listar();
            return View(Lista);
        }

        public IActionResult CrearTipoCampana()
        {//Metodo para devolver la vista

            return View();
        }

        [HttpPost]
        public IActionResult CrearTipoCampana(TipoCampanaModel TipoCampana)
        {//Metodo que recibe un objeto y lo guarda en la DB
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _TipoCampanaDatos.Guardar(TipoCampana);

            if (respuesta)
            {
                return RedirectToAction("ListarTipoCampana");
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult EditarTipoCampana(int cod_tipocampana)
        {
            var TipoCampana = _TipoCampanaDatos.Obtener(cod_tipocampana);
            return View(TipoCampana);
        }

        [HttpPost]
        public IActionResult EditarTipoCampana(TipoCampanaModel TipoCampana)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _TipoCampanaDatos.Editar(TipoCampana);

            if (respuesta)
            {
                return RedirectToAction("ListarTipoCampana");
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult EliminarTipoCampana(int cod_tipocampana)
        {
            var TipoCampana = _TipoCampanaDatos.Obtener(cod_tipocampana);
            return View(TipoCampana);
        }

        [HttpPost]
        public IActionResult EliminarTipoCampana(TipoCampanaModel TipoCampana)
        {
            var respuesta = _TipoCampanaDatos.Eliminar(TipoCampana);

            if (respuesta)
            {
                return RedirectToAction("ListarTipoCampana");
            }
            else
            {
                return View();
            }
            return View();
        }
    }
}
