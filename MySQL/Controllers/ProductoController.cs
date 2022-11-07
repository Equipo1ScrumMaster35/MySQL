using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySQL.IDataAccess;
using MySQL.Models;
using Microsoft.AspNetCore.Authorization;

namespace MySQL.Controllers
{
    [Authorize(Roles = "1")]
    public class ProductoController : Controller
    {
        ProductoDatos _ProductoDatos = new ProductoDatos();

        public ActionResult ListarProducto()
        {
            var Lista = _ProductoDatos.Listar();
            return View(Lista);
        }

        public IActionResult CrearProducto()
        {//Metodo para devolver la vista
            ViewBag.ListaTipo = new SelectList(_ProductoDatos.ListarTipoProducto(), "cod_tipoproducto", "nom_tipoproducto");
            return View();
        }

        [HttpPost]
        public IActionResult CrearProducto(ProductoModel Producto)
        {//Metodo que recibe un objeto y lo guarda en la DB

            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _ProductoDatos.Guardar(Producto);

            if (respuesta)
            {
                return RedirectToAction("ListarProducto");
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult EditarProducto(int cod_producto)
        {
            ViewBag.ListaTipo = new SelectList(_ProductoDatos.ListarTipoProducto(), "cod_tipoproducto", "nom_tipoproducto");
            var Producto = _ProductoDatos.Obtener(cod_producto);
            return View(Producto);
        }

        [HttpPost]
        public IActionResult EditarProducto(ProductoModel Producto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _ProductoDatos.Editar(Producto);

            if (respuesta)
            {
                return RedirectToAction("ListarProducto");
            }
            else
            {
                return View();
            }
            return View();
        }
    }
}
