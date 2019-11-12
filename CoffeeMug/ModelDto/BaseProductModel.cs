using System.ComponentModel.DataAnnotations;

namespace CoffeeMug.ModelDto
{
    public abstract class BaseProductModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        public double? Price { get; set; }
    }
}
