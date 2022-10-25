using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySQL.IDataAccess;

namespace MySQL.Controllers
{
    public class VistasController : Controller
    {
        PaisDatos _PaisDatos = new PaisDatos();

        // GET: VistasController
        public ActionResult ListarPais()
        {
            var Lista = _PaisDatos.Listar();
            return View(Lista);
        }

        // GET: VistasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VistasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VistasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VistasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VistasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VistasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VistasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
