using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            ///oracle ,Sql,postgres,MongoDb
            _products = new List<Product> {
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",Unitprice=15,UnitsInStock=15},
                new Product{ProductId=3,CategoryId=1,ProductName="Klavye",Unitprice=15,UnitsInStock=3},
                new Product{ProductId=4,CategoryId=2,ProductName="Mause",Unitprice=15,UnitsInStock=2},
                new Product{ProductId=5,CategoryId=2,ProductName="Kalem",Unitprice=15,UnitsInStock=65},
                new Product{ProductId=6,CategoryId=1,ProductName="Monitor",Unitprice=15,UnitsInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integreted Query 
            //Lambda
            //SingleOrDefault Foreach yap demek

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //göderdiğim ürün ID sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.Unitprice = product.Unitprice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
