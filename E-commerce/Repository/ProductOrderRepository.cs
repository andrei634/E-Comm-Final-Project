using E_commerce.Data;
using E_commerce.Models;
using E_commerce.Models.DBObjects;

namespace E_commerce.Repository
{
    public class ProductOrderRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public ProductOrderRepository()
        {
            _DbContext = new ApplicationDbContext();
        }

        public ProductOrderRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        private ProductOrderModel MapDBObjectToModel(ProductOrder dbObject)
        {
            var model = new ProductOrderModel();

            if (dbObject != null)
            {
                model.IdProduct = dbObject.IdProduct;
                model.IdOrder = dbObject.IdOrder;
                model.Quantity = dbObject.Quantity;
                model.Price = dbObject.Price;
                model.IdProductOrder = dbObject.IdProductOrder;
                model.ProductTitle = dbObject.ProductTitle;
            }

            return model;
        }

        private ProductOrder MapModelToDBObject(ProductOrderModel model)
        {
            var dbObject = new ProductOrder();

            if (model != null)
            {
                dbObject.IdProduct = model.IdProduct;
                dbObject.IdOrder = model.IdOrder;
                dbObject.Quantity = model.Quantity;
                dbObject.Price = model.Price;
                dbObject.IdProductOrder = model.IdProductOrder;
                dbObject.ProductTitle = model.ProductTitle;
            }

            return dbObject;
        }

        public List<ProductOrderModel> GetAllProductCart()
        {
            var list = new List<ProductOrderModel>();
            foreach (var dbObject in _DbContext.ProductOrders)
            {
                list.Add(MapDBObjectToModel(dbObject));
            }

            return list;
        }

        //public List<ProductOrderModel> GetAllProductOrderOfOneUser(Guid id)
        //{
        //    var list = new List<ProductCartModel>();
        //    foreach (var dbObject in _DbContext.ProductOrders)
        //    {
        //        if (dbObject.IdOrder == id)
        //        {
        //            list.Add(MapDBObjectToModel(dbObject));
        //        }
        //    }

        //    return list;
        //}

        public void InsertProductInOrder(ProductOrderModel model)
        {
            model.IdProductOrder = Guid.NewGuid();
            _DbContext.ProductOrders.Add(MapModelToDBObject(model));
            _DbContext.SaveChanges();
        }
    }
}
