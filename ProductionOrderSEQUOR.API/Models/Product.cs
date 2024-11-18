﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductionOrderSEQUOR.API.Models
{
    public partial class Product
    {
        public Product()
        {
            MaterialCode = new HashSet<Material>();
        }

        [Key]
        [StringLength(50)]
        [Unicode(false)]
        public string ProductCode { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string ProductDescription { get; set; }
        [Required]
        [StringLength(500)]
        [Unicode(false)]
        public string Image { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal CycleTime { get; set; }

        [ForeignKey("ProductCode")]
        [InverseProperty("ProductCode")]
        public virtual ICollection<Material> MaterialCode { get; set; }
    }
}