using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //global değişken
        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ -  Language Integrated Query
            Product productToDelete; // = new Product(); 201 nolu referans olur burada new denmez yanlıştır.

            #region LINQ kullanmasaydık.
            //foreach (var p in _products)   bu manuel yazım alttaki linq aynı işi yappıyor.
            //{
            //    if(product.ProductId ==p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //} 
            #endregion
            productToDelete = _products.SingleOrDefault(p =>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public  List<Product> GetAll()
        {
            return _products;
        }
        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan ürün idsine sahip ürünü bul.
            Product prodcotToUpdate = _products.SingleOrDefault(p=> product.ProductId == product.ProductId);
            prodcotToUpdate.ProductName = product.ProductName;
            prodcotToUpdate.CategoryId = product.CategoryId;
            prodcotToUpdate.UnitPrice = product.UnitPrice;
            prodcotToUpdate.UnitsInStock = product.UnitsInStock;
            
        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
