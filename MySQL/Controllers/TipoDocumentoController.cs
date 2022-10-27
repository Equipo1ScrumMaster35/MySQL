using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySQL.IDataAccess;
using MySQL.Models;

namespace MySQL.Controllers
{
    public class TipoDocumentoController : Controller
    {
        TipoDocumentoDatos _TipoDocumentoDatos = new TipoDocumentoDatos();
        public ActionResult ListarTipoDocumento()
        {
            var Lista = _TipoDocumentoDatos.Listar();
            return View(Lista);
        }

        public IActionResult CrearTipoDocumento()
        {//Metodo para devolver la vista

            return View();
        }

        [HttpPost]
        public IActionResult CrearTipoDocumento(TipoDocumentoModel TipoDocumento)
        {//Metodo que recibe un objeto y lo guarda en la DB
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _TipoDocumentoDatos.Guardar(TipoDocumento);

            if (respuesta)
            {
                return RedirectToAction("ListarTipoDocumento");
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult EditarTipoDocumento(int cod_tipodocumento)
        {
            var TipoDocumento = _TipoDocumentoDatos.Obtener(cod_tipodocumento);
            return View(TipoDocumento);
        }

        [HttpPost]
        public IActionResult EditarTipoDocumento(TipoDocumentoModel TipoDocumento)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _TipoDocumentoDatos.Editar(TipoDocumento);

            if (respuesta)
            {
                return RedirectToAction("ListarTipoDocumento");
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult EliminarTipoDocumento(int cod_tipodocumento)
        {
            var TipoDocumento = _TipoDocumentoDatos.Obtener(cod_tipodocumento);
            return View(TipoDocumento);
        }

        [HttpPost]
        public IActionResult EliminarTipoDocumento(TipoDocumentoModel TipoDocumento)
        {
            var respuesta = _TipoDocumentoDatos.Eliminar(TipoDocumento);

            if (respuesta)
            {
                return RedirectToAction("ListarTipoDocumento");
            }
            else
            {
                return View();
            }
            return View();
        }

    }
}
