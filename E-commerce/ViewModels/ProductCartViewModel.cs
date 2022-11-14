using E_commerce.Models;
using E_commerce.Repository;

namespace E_commerce.ViewModels
{
    public class ProductCartViewModel
    {
        public Guid IdProduct { get; set; }
        public Guid IdCart { get; set; }
        public int Quantity { get; set; }
        public Guid IdProductCart { get; set; }
        public string ProductTitle { get; set; }
        public double ProductPrice { get; set; }
        public string ProductImage { get; set; }

        public ProductCartViewModel(ProductRepository productRepository, ProductCartModel model)
        {
            this.IdProduct = model.IdProduct;
            this.IdCart = model.IdCart;
            this.Quantity = model.Quantity;
            this.IdProductCart = model.IdProductCart;
            var product = productRepository.GetProductById(model.IdProduct);
            this.ProductTitle = product.Title;
            this.ProductPrice = product.Price;
            this.ProductImage = product.Image;
        }
    }
}
