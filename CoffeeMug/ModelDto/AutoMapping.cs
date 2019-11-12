using AutoMapper;
using CoffeeMug.Model;

namespace CoffeeMug.ModelDto
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ProductCreateInputModel, Product>(); 
            CreateMap<Product, ProductOutputModel>(); 
            CreateMap<ProductUpdateInputModel, Product>(); 
        }
    }
}
