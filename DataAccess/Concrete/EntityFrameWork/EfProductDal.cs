﻿using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    //NuGet 
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //daha performanslı oluyor bu using sayesinde IDisposable pattern implementation of c# araştır.
            using (NorthwindContext context = new NorthwindContext()) 
            {
                var addedEntity = context.Entry(entity); //veri kaynağınla ilişkkilendirdim şimdi ne yapayım.
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); //veri kaynağınla ilişkkilendirdim şimdi ne yapayım.
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); //veri kaynağınla ilişkkilendirdim şimdi ne yapayım.
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}