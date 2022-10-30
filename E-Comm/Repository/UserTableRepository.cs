using E_Comm.Models;
using E_Comm.Models.DBObjects;

namespace E_Comm.Repository
{
    public class UserTableRepository
    {
        private readonly EcommContext _DbContext;

        public UserTableRepository()
        {
            _DbContext = new EcommContext();
        }

        public UserTableRepository(EcommContext dbContext)
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

        public UserTableModel GetUserById(string id)
        {
            return MapDBObjectToModel(_DbContext.UserTables.FirstOrDefault(x => x.IdUser == id));
        }

        public void InsertUser(UserTableModel model)
        {
            //model.IdUser = Guid.NewGuid();
            _DbContext.UserTables.Add(MapModelToDBObject(model));
            _DbContext.SaveChanges();
        }

        public void UpdateUser(UserTableModel model)
        {
            var dbObject = _DbContext.UserTables.FirstOrDefault(x => x.IdUser == model.IdUser);

            if (dbObject != null)
            {
                dbObject.IdUser = model.IdUser;
                _DbContext.SaveChanges();
            }
        }

        public void DeleteUser(string id)
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
