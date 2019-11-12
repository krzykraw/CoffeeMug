using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeMug.ModelDto
{
    public class ProductUpdateInputModel: BaseProductModel
    {
        [Required]
        public Guid? Id { get; set; }
    }
}
