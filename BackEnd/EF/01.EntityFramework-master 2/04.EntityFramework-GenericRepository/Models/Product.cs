﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityFrameworkDemo.Models
{
    public partial class Product : BaseEntity
    {
        public Product()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        [Required]
        public string Name { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [InverseProperty(nameof(ProductOrder.Product))]
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
