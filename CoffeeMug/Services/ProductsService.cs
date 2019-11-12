using AutoMapper;
using CoffeeMug.Model;
using CoffeeMug.ModelDto;
using CoffeeMug.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMug.Services
{
    public class ProductsService : IProductService
    {
        protected readonly IProductsRepository _productsRepository;
        protected readonly IMapper _mapper;

        public ProductsService(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public Guid Add(ProductCreateInputModel model)
        {
            var product = _mapper.Map<Product>(model);
            return _productsRepository.Add(product);
        }

        public bool Delete(Guid id)
        {
            return _productsRepository.Delete(id);
        }

        public ProductOutputModel Get(Guid id)
        {
            var product = _productsRepository.GetAll(x => x.Id == id).FirstOrDefault();
            if (product == null)
                return null;
            return _mapper.Map<ProductOutputModel>(product);
        }

        public IEnumerable<ProductOutputModel> GetAll()
        {
            var products = _productsRepository.GetAll().Select(product => _mapper.Map<ProductOutputModel>(product));
            return products;
        }

        public bool Update(ProductUpdateInputModel model)
        {
            var product=_mapper.Map<Product>(model);
            return _productsRepository.Update(product);
        }
    }
}
