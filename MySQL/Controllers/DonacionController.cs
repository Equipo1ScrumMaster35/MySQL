using Microsoft.AspNetCore.Mvc;
using MySQL.IDataAccess;

namespace MySQL.Controllers
{
    public class DonacionController : Controller
    {
        DonacionDatos _DonacionDatos = new DonacionDatos();
        public IActionResult EleccionPuntoFisico()
        {
            var Lista = _DonacionDatos.ListarPuntoFisico();
            return View(Lista);
        }

        public IActionResult RegistroDonante()
        {
            return View();
        }

    }
}
