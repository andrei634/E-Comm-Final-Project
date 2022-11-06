using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_comm.Controllers
{
    public class UserTableController : Controller
    {
        // GET: UserTableController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserTableController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserTableController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTableController/Create
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

        // GET: UserTableController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserTableController/Edit/5
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

        // GET: UserTableController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserTableController/Delete/5
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
