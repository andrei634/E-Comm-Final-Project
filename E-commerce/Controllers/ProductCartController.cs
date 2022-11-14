using E_commerce.Data;
using E_commerce.Models;
using E_commerce.Repository;
using E_commerce.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    [Authorize(Roles = "User")]
    public class ProductCartController : Controller
    {
        private ProductCartRepository _productCartRepository;
        private ProductRepository _productRepository;
        private UserTableRepository _userTableRepository;
        private CartRepository _cartRepository;

        public ProductCartController(ApplicationDbContext dbContext)
        {
            _productCartRepository = new ProductCartRepository(dbContext);
            _productRepository = new ProductRepository(dbContext);
            _userTableRepository = new UserTableRepository(dbContext);
            _cartRepository = new CartRepository(dbContext);
        }
        // GET: ProductCartController
        public ActionResult Index()
        {
            var viewModelList = new List<ProductCartViewModel>();
            if (User.Identity.IsAuthenticated)
            {
                var email = User.Identity.Name.ToString();
                var user = _userTableRepository.GetUserByEmail(email);
                var cart = _cartRepository.GetCartByUserId(user.IdUser);
                var list = _productCartRepository.GetAllProductCartOfOneUser(cart.IdCart);
                foreach (var productCart in list)
                {
                    viewModelList.Add(new ProductCartViewModel(_productRepository, productCart));
                }
            }
            return View(viewModelList);
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
        public ActionResult Edit(Guid id)
        {
            var model = _productCartRepository.GetProductCartById(id);
            return View("EditProductCart", model);
        }

        // POST: ProductCartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new ProductCartModel();
                model.IdProductCart = id;
                var task = TryUpdateModelAsync(model);

                if(task.Result)
                {
                    _productCartRepository.UpdateProductCart(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditProductCart");
            }
        }

        // GET: ProductCartController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var productCart = _productCartRepository.GetProductCartById(id);
            var model = new ProductCartViewModel(_productRepository, productCart);
            return View("DeleteProductCart", model);
        }

        // POST: ProductCartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _productCartRepository.DeleteProductCart(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("DeleteProductCart", id);
            }
        }

        public double TotalPrice(IEnumerable<ProductCartViewModel> list)
        {
            double totalPrice = 0;
            foreach (var item in list)
            {
                totalPrice += item.Quantity * item.ProductPrice;
            }

            return totalPrice;
        }

        public List<ProductCartModel> GetAllProductCarts(string email)
        {
            var user = _userTableRepository.GetUserByEmail(email);
            var cart = _cartRepository.GetCartByUserId(user.IdUser);
            var list = _productCartRepository.GetAllProductCartOfOneUser(cart.IdCart);

            return list;
        }
    }
}
