using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WebApiDemo.Models
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Price { get; set; }
    }

    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("The Product Name cannot be blank.")
                .Length(0, 100)
                .WithMessage("The Product Name cannot be more than 100 characters.")
                .Must(IsValidName)
                .WithMessage("{PropertyName} should be all letters.");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("The Product Price must be at greather than 0.");
        }

        private bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }
}
