using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySQL.IDataAccess;
using MySQL.Models;

namespace MySQL.Controllers
{
    [Authorize(Roles = "1")]
    public class CampanaController : Controller
    {
        CampanaDatos _CampanaDatos = new CampanaDatos();
        public ActionResult ListarCampana()
        {
            var Lista = _CampanaDatos.Listar();
            return View(Lista);
        }

        public IActionResult CrearCampana()
        {//Metodo para devolver la vista
            ViewBag.ListaProyecto = new SelectList(_CampanaDatos.ListarProyecto(), "cod_proyecto", "nom_proyecto");
            ViewBag.ListaTipoCampana = new SelectList(_CampanaDatos.ListarTipoCampana(), "cod_tipocampana", "nom_tipocampana");
            return View();
        }

        [HttpPost]
        public IActionResult CrearCampana(CampanaModel Campana)
        {//Metodo que recibe un objeto y lo guarda en la DB
            ViewBag.ListaProyecto = new SelectList(_CampanaDatos.ListarProyecto(), "cod_proyecto", "nom_proyecto");
            ViewBag.ListaTipoCampana = new SelectList(_CampanaDatos.ListarTipoCampana(), "cod_tipocampana", "nom_tipocampana");

            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            var respuesta = _CampanaDatos.Guardar(Campana);

            if (respuesta)
            {
                return RedirectToAction("ListarCampana");
            }
            else
            {
                return View();
            }
        }

        public IActionResult EditarCampana(int cod_campana)
        {
            var Campana = _CampanaDatos.Obtener(cod_campana);
            return View(Campana);
        }

        [HttpPost]
        public IActionResult EditarCampana(CampanaModel Campana)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _CampanaDatos.Editar(Campana);

            if (respuesta)
            {
                return RedirectToAction("ListarCampana");
            }
            else
            {
                return View();
            }
           
        }
    }
}
