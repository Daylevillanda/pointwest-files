using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EntityFrameworkDemo.Models
{
    public class Product
    {
        // Convention is Id or TableNameId
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Price { get; set; }
    }
}
