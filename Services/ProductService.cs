using System.Collections.Generic;
using System.Linq;
using Commerce.Context;
using Commerce.Entity;
using Commerce.IServices;

namespace Commerce.Services
{
    public class ProductService : IProductRepository<Product>
    {
        private readonly CommerceDbContext _tContext;

        public ProductService(CommerceDbContext commerceDbContext)
        {
            _tContext = commerceDbContext;
        }

        public IQueryable<Product> GetList()
        {
            IQueryable<Product> products = _tContext.Products.Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).AsQueryable();

            return products;
        }

        public Product Detail(int id)
        {
            Product product = _tContext.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        public Product Add(Product product)
        {
            Product newProduct = product;
            _tContext.Products.Add(newProduct);
            _tContext.SaveChanges();

            return newProduct;
        }

        public void Update(Product product)
        {
            Product updateProduct = _tContext.Products.FirstOrDefault(x => x.Id == product.Id);
            updateProduct.Name = product.Name;
            updateProduct.IsDeleted = product.IsDeleted;
            _tContext.Products.Update(updateProduct);
            _tContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Product updateProduct = _tContext.Products.FirstOrDefault(x => x.Id == id);
            updateProduct.IsDeleted = true;
            _tContext.Products.Update(updateProduct);
            _tContext.SaveChanges();
        }
    }
}