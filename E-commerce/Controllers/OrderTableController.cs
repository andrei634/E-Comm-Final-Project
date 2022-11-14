using E_commerce.Data;
using E_commerce.Repository;
using E_commerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace E_commerce.Controllers
{
    [Authorize(Roles = "User")]
    public class OrderTableController : Controller
    {
        private UserTableRepository _userTableRepository;
        private CartRepository _cartRepository;
        private ProductCartRepository _productCartRepository;
        private ProductOrderRepository _productOrderRepository;
        private ProductRepository _productRepository;
        private OrderTableRepository _orderTableRepository;

        public OrderTableController(ApplicationDbContext dbContext)
        {
            _userTableRepository = new UserTableRepository(dbContext);
            _cartRepository = new CartRepository(dbContext);
            _productCartRepository = new ProductCartRepository(dbContext);
            _productOrderRepository = new ProductOrderRepository(dbContext);
            _productRepository = new ProductRepository(dbContext);
            _orderTableRepository = new OrderTableRepository(dbContext);
        }
        // GET: OrderTableController
        public ActionResult Index()
        {
            var email = User.Identity.Name.ToString();
            var user = _userTableRepository.GetUserByEmail(email);
            var orderList = _orderTableRepository.GetAllOrdersOfOneUser(user.IdUser);
            return View(orderList);
        }

        // GET: OrderTableController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderTableController/Create
        public ActionResult Create()
        {
            return View("CreateOrder");
        }

        // POST: OrderTableController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new OrderTableModel();
                model.IdOrder = Guid.NewGuid();
                model.TotalPrice = 0;

                var emailURI = User.FindFirst(ClaimTypes.Email);
                var email = emailURI.ToString().Substring(68);
                var user = _userTableRepository.GetUserByEmail(email);
                var cart = _cartRepository.GetCartByUserId(user.IdUser);
                var list = _productCartRepository.GetAllProductCartOfOneUser(cart.IdCart);
                model.IdUser = user.IdUser;

                foreach (var item in list)
                {
                    var product = _productRepository.GetProductById(item.IdProduct);
                    model.TotalPrice += product.Price * item.Quantity;
                }

                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (task.Result)
                {
                    _orderTableRepository.InsertOrder(model);
                }

                foreach (var item in list)
                {
                    var productOrdermodel = new ProductOrderModel();
                    productOrdermodel.IdOrder = model.IdOrder;
                    productOrdermodel.IdProduct = item.IdProduct;
                    productOrdermodel.Quantity = item.Quantity;
                    var product = _productRepository.GetProductById(item.IdProduct);
                    productOrdermodel.Price = product.Price;
                    productOrdermodel.ProductTitle = product.Title;
                    _productOrderRepository.InsertProductInOrder(productOrdermodel);
                }
                _productCartRepository.DeleteAllProductCartForOneUser(cart.IdCart);

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View("CreateOrder");
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
