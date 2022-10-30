using E_Comm.Models;
using E_Comm.Models.DBObjects;

namespace E_Comm.Repository
{
    public class ProductCartRepository
    {
        private readonly EcommContext _DbContext;

        public ProductCartRepository()
        {
            _DbContext = new EcommContext();
        }

        public ProductCartRepository(EcommContext dbContext)
        {
            _DbContext = dbContext;
        }

        private ProductCartModel MapDBObjectToModel(ProductCart dbObject)
        {
            var model = new ProductCartModel();

            if(dbObject != null)
            {
                model.IdProduct = dbObject.IdProduct;
                model.IdCart = dbObject.IdCart;
                model.Quantity = dbObject.Quantity;
            }

            return model;
        }

        private ProductCart MapModelToDBObject(ProductCartModel model)
        {
            var dbObject = new ProductCart();

            if(model != null)
            {
                dbObject.IdProduct = model.IdProduct;
                dbObject.IdCart = model.IdCart;
                dbObject.Quantity = model.Quantity;
            }

            return dbObject;
        }

        public List<ProductCartModel> GetAllProductCart()
        {
            var list = new List<ProductCartModel>(); 
            foreach(var dbObject in _DbContext.ProductCarts)
            {
                list.Add(MapDBObjectToModel(dbObject));
            }

            return list;
        }

    }
}
