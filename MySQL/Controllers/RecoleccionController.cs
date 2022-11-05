using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySQL.IDataAccess;
using MySQL.Models;

namespace MySQL.Controllers
{
    public class RecoleccionController : Controller
    {
        RecoleccionDatos _RecoleccionDatos = new RecoleccionDatos();
        static int cod_pto;
        static int doc_per;
        public IActionResult EleccionPuntoFisico()
        {
            var Lista = _RecoleccionDatos.ListarPuntoFisico();
            return View(Lista);
        }

        public IActionResult RegistroDonante(int cod_ptofisico)
        {//Agregar la list dinamica, esta quemada en el codigo
            cod_pto = cod_ptofisico;
            //ViewBag.ListaTipo = new SelectList(_RecoleccionDatos.ListarTipoDoc(), "cod_tipodocumento", "nom_tipodocumento");
            return View();
        }

        [HttpPost]
        public IActionResult RegistroDonante(PersonaModel Persona)
        {//Metodo que recibe un objeto y lo guarda en la DB

            if (!ModelState.IsValid)
            {
                return View();
            }
            var res = _RecoleccionDatos.ValidarPersona(Persona);

            var respuesta = _RecoleccionDatos.GuardarPersona(Persona, res);

            doc_per = Convert.ToInt32(Persona.doc_persona);

            if (respuesta)
            {
                return RedirectToAction("RecoleccionRegistro");
            }
            else
            {
                return RedirectToAction("RecoleccionRegistro");
            }
        }
        public IActionResult RecoleccionRegistro()
        {
            //ViewBag.Doc_persona = doc_per;
            //ViewBag.Cod_pto = cod_pto;
            ViewBag.ListaUnidad = new SelectList(_RecoleccionDatos.ListarUnidad(), "cod_unidad", "nom_unidad");
            ViewBag.ListaProducto = new SelectList(_RecoleccionDatos.ListarProducto(), "cod_producto", "nom_producto");


            return View();
        }

        [HttpPost]
        public IActionResult RecoleccionRegistro(DonacionModel Donacion)
        {
            return View();
        }






        public IActionResult RecoleccionAnonimo()
        {
            return View();
        }


    }
}
