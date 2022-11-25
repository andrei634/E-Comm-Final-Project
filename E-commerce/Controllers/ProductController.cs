using E_commerce.Data;
using E_commerce.Models;
using E_commerce.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_commerce.Controllers
{
    
    public class ProductController : Controller
    {
        private ProductRepository _productRepository;
        private UserTableRepository _userTableRepository;
        private CartRepository _cartRepository;
        private ProductCartRepository _productCartRepository;

        public ProductController(ApplicationDbContext dbContext)
        {
            _productRepository = new ProductRepository(dbContext);
            _userTableRepository = new UserTableRepository(dbContext);
            _cartRepository = new CartRepository(dbContext);
            _productCartRepository = new ProductCartRepository(dbContext);
        }
        [Authorize(Roles = "User, Admin")]
        // GET: ProductController
        public ActionResult Index(string searchInput, string sortOrder)
        {
            var productList = _productRepository.GetAllProducts().ToList();
            if(!String.IsNullOrEmpty(searchInput))
            {
                productList = productList.Where(x => x.Title!.Contains(searchInput)).ToList();
            }

            if(sortOrder == "Ascending")
            {
                productList = productList.OrderBy(x => x.Price).ToList();
            } 
            else if (sortOrder == "Descending")
            {
                productList = productList.OrderByDescending(x => x.Price).ToList();
            }
            return View(productList);
        }
        [Authorize(Roles = "User, Admin")]
        // GET: ProductController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _productRepository.GetProductById(id);
            return View("Details", model);
        }
        [Authorize(Roles = "Admin")]
        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View("CreateProduct");
        }
        [Authorize(Roles = "Admin")]
        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new ProductModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();

                if (task.Result)
                {
                    _productRepository.InsertProduct(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateProduct");
            }
        }
        [Authorize(Roles = "Admin")]
        // GET: ProductController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _productRepository.GetProductById(id);
            return View("EditProduct", model);
        }
        [Authorize(Roles = "Admin")]
        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new ProductModel();
                model.IdProduct = id;
                var task = TryUpdateModelAsync(model);
                task.Wait();

                if(task.Result)
                {
                    _productRepository.UpdateProduct(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditProduct");
            }
        }

        public ActionResult AddProductInCart(Guid id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var email = User.Identity.Name.ToString();
                var user = _userTableRepository.GetUserByEmail(email);
                var cart = _cartRepository.GetCartByUserId(user.IdUser);
                var model = new ProductCartModel();
                model.IdCart = cart.IdCart;
                model.IdProduct = id;
                model.Quantity = 1;
                _productCartRepository.InsertProductInCart(model);
            }
            var productModel = _productRepository.GetProductById(id);
            return View("Details", productModel);
        }

        public ActionResult RemoveProductFromCart(Guid id)
        {
            var email = User.Identity.Name.ToString();
            var user = _userTableRepository.GetUserByEmail(email);
            var cart = _cartRepository.GetCartByUserId(user.IdUser);
            _productCartRepository.DeleteProductCart(id, cart.IdCart);
            var productModel = _productRepository.GetProductById(id);
            return View("Details", productModel);
        }

        [Authorize(Roles = "Admin")]
        // GET: ProductController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _productRepository.GetProductById(id);
            return View("DeleteProduct", model);
        }
        [Authorize(Roles = "Admin")]
        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _productRepository.DeleteProduct(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("DeleteProduct", id);
            }
        }

        public bool IsInCart(Guid id, string email)
        {
            bool isInCart = false;
            var user = _userTableRepository.GetUserByEmail(email);
            var cart = _cartRepository.GetCartByUserId(user.IdUser);
            var list = _productCartRepository.GetAllProductCartOfOneUser(cart.IdCart);
            foreach (var item in list)
            {
                if (item.IdProduct == id)
                {
                    isInCart = true;
                }
            }
            return isInCart;
        }

        public List<ProductModel> GetSimilarProducts(ProductModel model)
        {
            var list = _productRepository.GetAllProducts();
            var similarProducts = new List<ProductModel>();

            foreach(var item in list)
            {
                if (item.Category == model.Category && item.IdProduct != model.IdProduct)
                {
                    similarProducts.Add(item);
                }
            }

            return similarProducts;
        }
    }
}
