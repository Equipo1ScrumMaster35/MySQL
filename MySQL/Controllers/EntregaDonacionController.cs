using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySQL.IDataAccess;
using MySQL.Models;
using Microsoft.AspNetCore.Authorization;

namespace MySQL.Controllers
{
    [Authorize(Roles = "1,2")]
    public class EntregaDonacionController : Controller
    {
        EntregaDonacionDatos _DonacionDatos = new EntregaDonacionDatos();
        static int cod_pto;
        static int doc_per;
        static int cod_ult;
        public IActionResult EleccionPuntoFisico()
        {
            var Lista = _DonacionDatos.ListarPuntoFisico();
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
            var res = _DonacionDatos.ValidarPersona(Persona);

            var respuesta = _DonacionDatos.GuardarPersona(Persona, res);

            doc_per = Convert.ToInt32(Persona.doc_persona);

            if (respuesta)
            {
                return RedirectToAction("DonacionRegistro");
            }
            else
            {
                return RedirectToAction("DonacionRegistro");
            }
        }
        public IActionResult DonacionRegistro()
        {
            //ViewBag.Doc_persona = doc_per;
            //ViewBag.Cod_pto = cod_pto;
            //ViewBag.ListaUnidad = new SelectList(_RecoleccionDatos.ListarUnidad(), "cod_unidad", "nom_unidad");
            ViewBag.ListaProducto = new SelectList(_DonacionDatos.ListarProducto(), "cod_producto", "nom_producto");

            return View();
        }

        [HttpPost]
        public IActionResult DonacionRegistro(EntregaDonacionModel Donacion)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _DonacionDatos.RegistrarDonacion(Donacion, doc_per, cod_pto);


            if (respuesta)
            {
                cod_ult = _DonacionDatos.UltimaDonacion();

                _DonacionDatos.RegistrarDetalleDonacion(Donacion, cod_ult);

                return RedirectToAction("EleccionPuntoFisico");
            }
            else
            {
                return View();
            }
        }
    }
}
