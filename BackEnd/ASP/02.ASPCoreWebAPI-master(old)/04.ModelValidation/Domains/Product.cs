using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Domains
{

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }

    public class ProductValidator : AbstractValidator<Product>
    {
        /// <summary>  
        /// Validator rules for Product  
        /// </summary>  
        public ProductValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("The Product ID must be at greather than 0.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("The Product Name cannot be blank.")
                .Length(0, 100)
                .WithMessage("The Product Name cannot be more than 100 characters.")
                .Must(IsValidName)
                .WithMessage("{PropertyName} should be all letters.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("The Product Description must be at least 150 characters long.");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("The Product Price must be at greather than 0.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password cannot be blank.")
                .Equal(x => x.ConfirmPassword)
                .WithMessage("Please confirm password");
        }

        private bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }

}
