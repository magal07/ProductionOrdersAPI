﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductionOrderSEQUOR.API.Models
{
    public partial class Order
    {
        public Order()
        {
            Production = new HashSet<Production>();
        }

        [Key]
        [Column("OrderID")]
        [StringLength(50)]
        [Unicode(false)]
        public string OrderId { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal Quantity { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string ProductCode { get; set; }

        [InverseProperty("Order")]
        public virtual ICollection<Production> Production { get; set; }
    }
}