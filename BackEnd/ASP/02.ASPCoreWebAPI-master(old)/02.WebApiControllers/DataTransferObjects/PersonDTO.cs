using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.DataTransferObjects
{
    public class PersonDTO
    {
        public PersonDTO() : this("", "", 0)
        {
        }

        public PersonDTO(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(100, ErrorMessage = "First name length can't be more than 100.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(100, ErrorMessage = "First name length can't be more than 100.")]
        public string LastName { get; set; }

        [Range(minimum: 18, maximum: 65, ErrorMessage = "Age does not fall within allowed range [18-65].")]
        public int Age { get; set; }

        [EmailAddress(ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Compare(nameof(NewPassword), ErrorMessage = "Passwords don't match.")]
        public string RepeatPassword { get; set; }
    }
}
