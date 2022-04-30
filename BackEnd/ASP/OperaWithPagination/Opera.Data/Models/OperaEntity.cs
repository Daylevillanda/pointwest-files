using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operas.Data.Models
{
    public class OperaEntity: BaseEntity
    {
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Title { get; set; }

        [Required]
        [CheckValidYear]
        public int Year { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Composer { get; set; }
    }

    public class CheckValidYear : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int year = (int)value;
            if (year < 1958 || year > DateTime.Now.Year)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public CheckValidYear()
        {
            ErrorMessage = "The earliest opera is Daphne, 1598, by Corsi, Peri, and Rinuccini";
        }

        public CheckValidYear(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
