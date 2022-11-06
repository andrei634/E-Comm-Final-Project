using E_commerce.Data;
using E_commerce.Models;
using E_commerce.Models.DBObjects;

namespace E_commerce.Repository
{
    public class CartRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public CartRepository()
        {
            _DbContext = new ApplicationDbContext();
        }

        public CartRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        private CartModel MapDBObjectToModel(Cart dbObject)
        {
            var model = new CartModel();

            if (dbObject != null)
            {
                model.IdCart = dbObject.IdCart;
                model.IdUser = dbObject.IdUser;
            }

            return model;
        }

        private Cart MapModelToDBObject(CartModel model)
        {
            var dbObject = new Cart();

            if (model != null)
            {
                dbObject.IdCart = model.IdCart;
                dbObject.IdUser = model.IdUser;
            }

            return dbObject;
        }

        public List<CartModel> GetAllCarts()
        {
            var list = new List<CartModel>();

            foreach (var dbObject in _DbContext.Carts)
            {
                list.Add(MapDBObjectToModel(dbObject));
            }

            return list;
        }

        public CartModel GetCartById(Guid id)
        {
            return MapDBObjectToModel(_DbContext.Carts.FirstOrDefault(x => x.IdCart == id));
        }

        public void InsertCart(CartModel model)
        {
            model.IdCart = Guid.NewGuid();
            _DbContext.Carts.Add(MapModelToDBObject(model));
            _DbContext.SaveChanges();
        }

        public void UpdateCart(CartModel model)
        {
            var dbObject = _DbContext.Carts.FirstOrDefault(x => x.IdCart == model.IdCart);

            if (dbObject != null)
            {
                dbObject.IdCart = model.IdCart;
                dbObject.IdUser = model.IdUser;
                _DbContext.SaveChanges();
            }
        }

        public void DeleteCart(Guid id)
        {
            var dbObject = _DbContext.Carts.FirstOrDefault(x => x.IdCart == id);

            if (dbObject != null)
            {
                _DbContext.Carts.Remove(dbObject);
                _DbContext.SaveChanges();
            }
        }
    }
}
