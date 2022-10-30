using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Comm.Controllers
{
    public class ProductCartController : Controller
    {
        // GET: ProductCartController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductCartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductCartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductCartController/Create
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

        // GET: ProductCartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductCartController/Edit/5
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

        // GET: ProductCartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductCartController/Delete/5
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
