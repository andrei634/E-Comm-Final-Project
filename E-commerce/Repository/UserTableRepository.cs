using E_commerce.Data;
using E_commerce.Models;
using E_commerce.Models.DBObjects;

namespace E_commerce.Repository
{
    public class UserTableRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public UserTableRepository()
        {
            _DbContext = new ApplicationDbContext();
        }

        public UserTableRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        private UserTableModel MapDBObjectToModel(UserTable dbObject)
        {
            var model = new UserTableModel();

            if (dbObject != null)
            {
                model.IdUser = dbObject.IdUser;
                model.FirstName = dbObject.FirstName;
                model.LastName = dbObject.LastName;
                model.City = dbObject.City;
                model.ZipCode = dbObject.ZipCode;
                model.Street = dbObject.Street;
                model.StreetNumber = dbObject.StreetNumber;
                model.EmailAddress = dbObject.EmailAddress;
            }

            return model;
        }

        private UserTable MapModelToDBObject(UserTableModel model)
        {
            var dbObject = new UserTable();

            if (model != null)
            {
                dbObject.IdUser = model.IdUser;
                dbObject.FirstName = model.FirstName;
                dbObject.LastName = model.LastName;
                dbObject.City = model.City;
                dbObject.ZipCode = model.ZipCode;
                dbObject.Street = model.Street;
                dbObject.StreetNumber = model.StreetNumber;
                dbObject.EmailAddress = model.EmailAddress;
            }

            return dbObject;
        }

        private Cart MapModelToDBObjectForCart(CartModel model)
        {
            var dbObject = new Cart();

            if (model != null)
            {
                dbObject.IdCart = model.IdCart;
                dbObject.IdUser = model.IdUser;
            }

            return dbObject;
        }

        public List<UserTableModel> GetAllUsers()
        {
            var list = new List<UserTableModel>();

            foreach (var dbObject in _DbContext.UserTables)
            {
                list.Add(MapDBObjectToModel(dbObject));
            }

            return list;
        }

        public UserTableModel GetUserById(Guid id)
        {
            return MapDBObjectToModel(_DbContext.UserTables.FirstOrDefault(x => x.IdUser == id));
        }

        public UserTableModel GetUserByEmail(string email)
        {
            return MapDBObjectToModel(_DbContext.UserTables.FirstOrDefault(x => x.EmailAddress == email));
        }

        public void InsertUser(UserTableModel model)
        {
            var cartModel = new CartModel();
            model.IdUser = Guid.NewGuid();
            cartModel.IdUser = model.IdUser;
            _DbContext.UserTables.Add(MapModelToDBObject(model));
            _DbContext.SaveChanges();
            CreateCartForUser(cartModel);
        }

        public void CreateCartForUser(CartModel model)
        {
            model.IdCart = Guid.NewGuid();
            _DbContext.Carts.Add(MapModelToDBObjectForCart(model));
            _DbContext.SaveChanges();
        }

        public void UpdateUser(UserTableModel model)
        {
            var dbObject = _DbContext.UserTables.FirstOrDefault(x => x.IdUser == model.IdUser);

            if (dbObject != null)
            {
                dbObject.IdUser = model.IdUser;
                dbObject.FirstName = model.FirstName;
                dbObject.LastName = model.LastName;
                dbObject.City = model.City;
                dbObject.ZipCode = model.ZipCode;
                dbObject.Street = model.Street;
                dbObject.StreetNumber = model.StreetNumber;
                dbObject.EmailAddress = model.EmailAddress;
                _DbContext.SaveChanges();
            }
        }

        public void DeleteUser(Guid id)
        {
            var dbObject = _DbContext.UserTables.FirstOrDefault(x => x.IdUser == id);

            if (dbObject != null)
            {
                _DbContext.UserTables.Remove(dbObject);
                _DbContext.SaveChanges();
            }
        }
    }
}
