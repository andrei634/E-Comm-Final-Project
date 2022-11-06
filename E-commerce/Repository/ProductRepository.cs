using E_commerce.Data;
using E_commerce.Models;
using E_commerce.Models.DBObjects;

namespace E_commerce.Repository
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public ProductRepository()
        {
            _DbContext = new ApplicationDbContext();
        }

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        private ProductModel MapDBObjectToModel(Product dbObject)
        {
            var model = new ProductModel();

            if (dbObject != null)
            {
                model.IdProduct = dbObject.IdProduct;
                model.Title = dbObject.Title;
                model.Description = dbObject.Description;
                model.Price = dbObject.Price;
                model.Rating = dbObject.Rating;
                model.Image = dbObject.Image;
                model.Category = dbObject.Category;
            }

            return model;
        }

        private Product MapModelToDBObject(ProductModel model)
        {
            var dbObject = new Product();

            if (model != null)
            {
                dbObject.IdProduct = model.IdProduct;
                dbObject.Title = model.Title;
                dbObject.Description = model.Description;
                dbObject.Price = model.Price;
                dbObject.Rating = model.Rating;
                dbObject.Image = model.Image;
                dbObject.Category = model.Category;
            }

            return dbObject;
        }

        public List<ProductModel> GetAllProducts()
        {
            var list = new List<ProductModel>();

            foreach (var dbObject in _DbContext.Products)
            {
                list.Add(MapDBObjectToModel(dbObject));
            }

            return list;
        }

        public ProductModel GetProductById(Guid id)
        {
            return MapDBObjectToModel(_DbContext.Products.FirstOrDefault(x => x.IdProduct == id));
        }

        public void InsertProduct(ProductModel model)
        {
            model.IdProduct = Guid.NewGuid();
            _DbContext.Products.Add(MapModelToDBObject(model));
            _DbContext.SaveChanges();
        }

        public void UpdateProduct(ProductModel model)
        {
            var dbObject = _DbContext.Products.FirstOrDefault(x => x.IdProduct == model.IdProduct);

            if (dbObject != null)
            {
                dbObject.IdProduct = model.IdProduct;
                dbObject.Title = model.Title;
                dbObject.Description = model.Description;
                dbObject.Price = model.Price;
                dbObject.Rating = model.Rating;
                dbObject.Image = model.Image;
                dbObject.Category = model.Category;
                _DbContext.SaveChanges();
            }
        }

        public void DeleteProduct(Guid id)
        {
            var dbObject = _DbContext.Products.FirstOrDefault(x => x.IdProduct == id);

            if (dbObject != null)
            {
                _DbContext.Products.Remove(dbObject);
                _DbContext.SaveChanges();
            }
        }
    }
}
