using E_commerce.Data;
using E_commerce.Models;
using E_commerce.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_commerce.Controllers
{
    public class UserTableController : Controller
    {
        private UserTableRepository _userTableRepository;

        public UserTableController(ApplicationDbContext dbContext)
        {
            _userTableRepository = new UserTableRepository(dbContext);
        }
        // GET: UserTableController
        public ActionResult Index()
        {
            var list = _userTableRepository.GetAllUsers();
            return View(list);
        }

        // GET: UserTableController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserTableController/Create
        public ActionResult Create()
        {
            return View("CreateUser");
        }

        // POST: UserTableController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new UserTableModel();

                if (User.Identity.IsAuthenticated)
                {
                    //var emailURI = User.FindFirst(ClaimTypes.Email);
                    //var email = emailURI.ToString().Substring(68);
                    var email = User.Identity.Name.ToString();
                    model.EmailAddress = email;
                }

                var task = TryUpdateModelAsync(model);
                task.Wait();

                if(task.Result)
                {
                    _userTableRepository.InsertUser(model);
                }
                return RedirectToAction("Index", "Product");
            }
            catch
            {
                return View("CreateUser");
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
