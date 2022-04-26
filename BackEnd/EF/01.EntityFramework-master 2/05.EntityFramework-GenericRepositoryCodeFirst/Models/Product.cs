using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EntityFrameworkDemo.Models
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Price { get; set; }
    }
}
