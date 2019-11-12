using CoffeeMug.ModelDto;
using System;
using System.Collections.Generic;

namespace CoffeeMug.Services
{
    public interface IProductService
    {
        IEnumerable<ProductOutputModel> GetAll();
        ProductOutputModel Get(Guid id);
        bool Update(ProductUpdateInputModel model);
        bool Delete(Guid id);
        Guid Add(ProductCreateInputModel model);
    }
}
