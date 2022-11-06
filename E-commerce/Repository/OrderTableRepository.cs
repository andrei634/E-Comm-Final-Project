using E_commerce.Data;
using E_commerce.Models;
using E_commerce.Models.DBObjects;

namespace E_commerce.Repository
{
    public class OrderTableRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public OrderTableRepository()
        {
            _DbContext = new ApplicationDbContext();
        }

        public OrderTableRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        private OrderTableModel MapDBObjectToModel(OrderTable dbObject)
        {
            var model = new OrderTableModel();

            if (dbObject != null)
            {
                model.IdOrder = dbObject.IdOrder;
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
                dbObject.IdOrder = model.IdOrder;
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
            return MapDBObjectToModel(_DbContext.OrderTables.FirstOrDefault(x => x.IdOrder == id));
        }

        public void InsertOrder(OrderTableModel model)
        {
            model.IdOrder = Guid.NewGuid();
            _DbContext.OrderTables.Add(MapModelToDBObject(model));
            _DbContext.SaveChanges();
        }

        public void UpdateOrder(OrderTableModel model)
        {
            var dbObject = _DbContext.OrderTables.FirstOrDefault(x => x.IdOrder == model.IdOrder);

            if (dbObject != null)
            {
                dbObject.IdOrder = model.IdOrder;
                _DbContext.SaveChanges();
            }
        }

        public void DeleteOrder(Guid id)
        {
            var dbObject = _DbContext.OrderTables.FirstOrDefault(x => x.IdOrder == id);

            if (dbObject != null)
            {
                _DbContext.OrderTables.Remove(dbObject);
                _DbContext.SaveChanges();
            }
        }
    }
}
