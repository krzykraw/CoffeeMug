using CoffeeMug.Model;
using System;
using System.Collections.Generic;

namespace CoffeeMug.Repository
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAll(Func<Product, bool> predicate);
        Guid Add(Product product);
        bool Delete(Guid id);
        bool Update(Product product);
    }
}
