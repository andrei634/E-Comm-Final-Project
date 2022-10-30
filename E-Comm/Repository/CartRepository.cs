using E_Comm.Models;
using E_Comm.Models.DBObjects;

namespace E_Comm.Repository
{
    public class CartRepository
    {
        private readonly EcommContext _DbContext;

        public CartRepository()
        {
            _DbContext = new EcommContext();
        }

        public CartRepository(EcommContext dbContext)
        {
            _DbContext = dbContext;
        }

        private CartModel MapDBObjectToModel(Cart dbObject)
        {
            var model = new CartModel();

            if(dbObject != null)
            {
                model.IdCart = dbObject.IdCart;
            }

            return model;
        }

        private Cart MapModelToDBObject(CartModel model)
        {
            var dbObject = new Cart();

            if(model != null)
            {
                dbObject.IdCart = model.IdCart;
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

            if(dbObject != null)
            {
                dbObject.IdCart = model.IdCart;
                _DbContext.SaveChanges();
            }
        }

        public void DeleteCart(Guid id)
        {
            var dbObject = _DbContext.Carts.FirstOrDefault(x => x.IdCart == id);

            if( dbObject != null )
            {
                _DbContext.Carts.Remove(dbObject);
                _DbContext.SaveChanges();
            }
        }
    }
}
