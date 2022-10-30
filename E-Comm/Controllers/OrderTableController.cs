using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Comm.Controllers
{
    public class OrderTableController : Controller
    {
        // GET: OrderTableController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderTableController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderTableController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderTableController/Create
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

        // GET: OrderTableController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderTableController/Edit/5
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

        // GET: OrderTableController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderTableController/Delete/5
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
