using E_Comm.Models;
using E_Comm.Models.DBObjects;

namespace E_Comm.Repository
{
    public class OrderTableRepository
    {
        private readonly EcommContext _DbContext;

        public OrderTableRepository()
        {
            _DbContext = new EcommContext();
        }

        public OrderTableRepository(EcommContext dbContext)
        {
            _DbContext = dbContext;
        }

        private OrderTableModel MapDBObjectToModel(OrderTable dbObject)
        {
            var model = new OrderTableModel();

            if (dbObject != null)
            {
                model.IdCart = dbObject.IdCart;
                model.Date = dbObject.Date;
                model.TotalPrice = dbObject.TotalPrice;
                model.City = dbObject.City;
                model.ZipCode = dbObject.ZipCode;
                model.Street = dbObject.Street;
                model.StreetNumber = dbObject.StreetNumber;
                model.IdUser = dbObject.IdUser;
            }

            return model;
        }

        private OrderTable MapModelToDBObject(OrderTableModel model)
        {
            var dbObject = new OrderTable();

            if (model != null)
            {
                dbObject.IdCart = model.IdCart;
                dbObject.Date = model.Date;
                dbObject.TotalPrice = model.TotalPrice;
                dbObject.City = model.City;
                dbObject.ZipCode = model.ZipCode;
                dbObject.Street = model.Street;
                dbObject.StreetNumber = model.StreetNumber;
                dbObject.IdUser = model.IdUser;
            }

            return dbObject;
        }

        public List<OrderTableModel> GetAllOrders()
        {
            var list = new List<OrderTableModel>();

            foreach (var dbObject in _DbContext.OrderTables)
            {
                list.Add(MapDBObjectToModel(dbObject));
            }

            return list;
        }

        public OrderTableModel GetOrderById(Guid id)
        {
            return MapDBObjectToModel(_DbContext.OrderTables.FirstOrDefault(x => x.IdCart == id));
        }

        public void InsertOrder(OrderTableModel model)
        {
            model.IdCart = Guid.NewGuid();
            _DbContext.OrderTables.Add(MapModelToDBObject(model));
            _DbContext.SaveChanges();
        }

        public void UpdateOrder(OrderTableModel model)
        {
            var dbObject = _DbContext.OrderTables.FirstOrDefault(x => x.IdCart == model.IdCart);

            if (dbObject != null)
            {
                dbObject.IdCart = model.IdCart;
                _DbContext.SaveChanges();
            }
        }

        public void DeleteOrder(Guid id)
        {
            var dbObject = _DbContext.OrderTables.FirstOrDefault(x => x.IdCart == id);

            if (dbObject != null)
            {
                _DbContext.OrderTables.Remove(dbObject);
                _DbContext.SaveChanges();
            }
        }
    }
}
