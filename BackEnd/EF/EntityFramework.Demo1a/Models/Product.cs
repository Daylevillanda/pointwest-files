using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Demo1a.Models
{
    //[Table("ProductItem")] -> customize the class name of Product
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //[Column("total_amount", TypeName = "DECIMAL(11, 2)")]
        [Column(TypeName = "DECIMAL(11, 2)")]
        [Required]
        public decimal Price { get; set; }
        public string ProductCode { get; set; }
    }
}
