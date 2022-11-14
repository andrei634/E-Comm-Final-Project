using E_commerce.Data;
using E_commerce.Models;
using E_commerce.Models.DBObjects;

namespace E_commerce.Repository
{
    public class ProductCartRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public ProductCartRepository()
        {
            _DbContext = new ApplicationDbContext();
        }

        public ProductCartRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        private ProductCartModel MapDBObjectToModel(ProductCart dbObject)
        {
            var model = new ProductCartModel();

            if (dbObject != null)
            {
                model.IdProduct = dbObject.IdProduct;
                model.IdCart = dbObject.IdCart;
                model.Quantity = dbObject.Quantity;
                model.IdProductCart = dbObject.IdProductCart;
            }

            return model;
        }

        private ProductCart MapModelToDBObject(ProductCartModel model)
        {
            var dbObject = new ProductCart();

            if (model != null)
            {
                dbObject.IdProduct = model.IdProduct;
                dbObject.IdCart = model.IdCart;
                dbObject.Quantity = model.Quantity;
                dbObject.IdProductCart = model.IdProductCart;
            }

            return dbObject;
        }

        public List<ProductCartModel> GetAllProductCart()
        {
            var list = new List<ProductCartModel>();
            foreach (var dbObject in _DbContext.ProductCarts)
            {
                list.Add(MapDBObjectToModel(dbObject));
            }

            return list;
        }

        public List<ProductCartModel> GetAllProductCartOfOneUser(Guid id)
        {
            var list = new List<ProductCartModel>();
            foreach (var dbObject in _DbContext.ProductCarts)
            {
                if (dbObject.IdCart == id)
                {
                    list.Add(MapDBObjectToModel(dbObject));
                }
            }

            return list;
        }

        public ProductCartModel GetProductCartById(Guid id)
        {
            return MapDBObjectToModel(_DbContext.ProductCarts.FirstOrDefault(x => x.IdProductCart == id));
        }

        public void InsertProductInCart(ProductCartModel model)
        {
            model.IdProductCart = Guid.NewGuid();
            _DbContext.ProductCarts.Add(MapModelToDBObject(model));
            _DbContext.SaveChanges();
        }

        public void UpdateProductCart(ProductCartModel model)
        {
            var dbObject = _DbContext.ProductCarts.FirstOrDefault(x => x.IdProductCart == model.IdProductCart);

            if(dbObject != null)
            {
                dbObject.IdProduct = model.IdProduct;
                dbObject.IdCart = model.IdCart;
                dbObject.Quantity = model.Quantity;
                dbObject.IdProductCart = model.IdProductCart;
                _DbContext.SaveChanges();
            }
        }

        public void DeleteProductCart(Guid id)
        {
            var dbObject = _DbContext.ProductCarts.FirstOrDefault(x => x.IdProductCart == id);

            if(dbObject != null )
            {
                _DbContext.ProductCarts.Remove(dbObject);
                _DbContext.SaveChanges();
            }
        }

        public void DeleteProductCart(Guid idProduct, Guid idCart)
        {
            var dbObject = _DbContext.ProductCarts.FirstOrDefault(x => x.IdProduct == idProduct && x.IdCart == idCart);

            if(dbObject != null)
            {
                _DbContext.ProductCarts.Remove(dbObject);
                _DbContext.SaveChanges();
            }
        }

        public void DeleteAllProductCartForOneUser(Guid idCart)
        {
            var list = _DbContext.ProductCarts.Where(x => x.IdCart == idCart).ToList();

            foreach(var item in list)
            {
                _DbContext.ProductCarts.Remove(item);
            }
            _DbContext.SaveChanges();
        }
    }
}
