using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySQL.IDataAccess;
using MySQL.Models;
using Microsoft.AspNetCore.Authorization;

namespace MySQL.Controllers
{
    [Authorize(Roles = "1")]
    public class PuntoFisicoController : Controller
    {
        PuntoFisicoDatos _PuntoFisicoDatos = new PuntoFisicoDatos();

        public ActionResult ListarPuntoFisico()
        {
            var Lista = _PuntoFisicoDatos.Listar();
            return View(Lista);
        }

        public IActionResult CrearPuntoFisico()
        {//Metodo para devolver la vista
            ViewBag.ListaCiudad = new SelectList(_PuntoFisicoDatos.ListarCiudad(), dataValueField:"cod_ciudad",dataTextField: "nom_ciudad");
            ViewBag.ListaIntegrante = new SelectList(_PuntoFisicoDatos.ListarIntegrante(), dataValueField: "doc_integrante", dataTextField:"nom_integrante");
            ViewBag.ListaCampana = new SelectList(_PuntoFisicoDatos.ListarCampana(), dataValueField: "cod_campana", dataTextField:"nom_campana");
            return View();
        }

        [HttpPost]
        public IActionResult CrearPuntoFisico(PuntoFisicoModel PtoFisico)
        {//Metodo que recibe un objeto y lo guarda en la DB
            ViewBag.ListaCiudad = new SelectList(_PuntoFisicoDatos.ListarCiudad(), dataValueField: "cod_ciudad", dataTextField: "nom_ciudad");
            ViewBag.ListaIntegrante = new SelectList(_PuntoFisicoDatos.ListarIntegrante(), dataValueField: "doc_integrante", dataTextField: "nom_integrante");
            ViewBag.ListaCampana = new SelectList(_PuntoFisicoDatos.ListarCampana(), dataValueField: "cod_campana", dataTextField: "nom_campana");

            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            var respuesta = _PuntoFisicoDatos.Guardar(PtoFisico);

            if (respuesta)
            {
                return RedirectToAction("ListarPuntoFisico");
            }
            else
            {
                return View();
            }
     
        }
        //Arreglar metodo de editar 
        public IActionResult EditarPuntoFisico(int cod_puntofisico)
        {
            ViewBag.ListaCiudad = new SelectList(_PuntoFisicoDatos.ListarCiudad(), dataValueField: "cod_ciudad", dataTextField: "nom_ciudad");
            ViewBag.ListaIntegrante = new SelectList(_PuntoFisicoDatos.ListarIntegrante(), dataValueField: "doc_integrante", dataTextField: "nom_integrante");
            ViewBag.ListaCampana = new SelectList(_PuntoFisicoDatos.ListarCampana(), dataValueField: "cod_campana", dataTextField: "nom_campana");
            var PtoFisico = _PuntoFisicoDatos.Obtener(cod_puntofisico);
            return View(PtoFisico);
        }

        [HttpPost]
        public IActionResult EditarPuntoFisico(PuntoFisicoModel PtoFisico)
        {
            ViewBag.ListaCiudad = new SelectList(_PuntoFisicoDatos.ListarCiudad(), dataValueField: "cod_ciudad", dataTextField: "nom_ciudad");
            ViewBag.ListaIntegrante = new SelectList(_PuntoFisicoDatos.ListarIntegrante(), dataValueField: "doc_integrante", dataTextField: "nom_integrante");
            ViewBag.ListaCampana = new SelectList(_PuntoFisicoDatos.ListarCampana(), dataValueField: "cod_campana", dataTextField: "nom_campana");
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            var respuesta = _PuntoFisicoDatos.Editar(PtoFisico);

            if (respuesta)
            {
                return RedirectToAction("ListarPuntoFisico");
            }
            else
            {
                return View();
            }
         
        }
    }
}
