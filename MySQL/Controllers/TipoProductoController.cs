using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySQL.IDataAccess;
using MySQL.Models;

namespace MySQL.Controllers
{
    public class TipoProductoController : Controller
    {
        TipoProductoDatos _TipoProductoDatos = new TipoProductoDatos();
        public ActionResult ListarTipoProducto()
        {
            var Lista = _TipoProductoDatos.Listar();
            return View(Lista);
        }

        public IActionResult CrearTipoProducto()
        {//Metodo para devolver la vista

            return View();
        }

        [HttpPost]
        public IActionResult CrearTipoProducto(TipoProductoModel TipoProducto)
        {//Metodo que recibe un objeto y lo guarda en la DB
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _TipoProductoDatos.Guardar(TipoProducto);

            if (respuesta)
            {
                return RedirectToAction("ListarTipoProducto");
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult EditarTipoProducto(int cod_tipoproducto)
        {
            var TipoProducto = _TipoProductoDatos.Obtener(cod_tipoproducto);
            return View(TipoProducto);
        }

        [HttpPost]
        public IActionResult EditarTipoProducto(TipoProductoModel TipoProducto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _TipoProductoDatos.Editar(TipoProducto);

            if (respuesta)
            {
                return RedirectToAction("ListarTipoProducto");
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult EliminarTipoProducto(int cod_tipoproducto)
        {
            var TipoProducto = _TipoProductoDatos.Obtener(cod_tipoproducto);
            return View(TipoProducto);
        }

        [HttpPost]
        public IActionResult EliminarTipoProducto(TipoProductoModel TipoProducto)
        {
            var respuesta = _TipoProductoDatos.Eliminar(TipoProducto);

            if (respuesta)
            {
                return RedirectToAction("ListarTipoProducto");
            }
            else
            {
                return View();
            }
            return View();
        }
    }
}
