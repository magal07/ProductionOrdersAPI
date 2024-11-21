﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductionOrderSEQUOR.API.Models
{
    public partial class User
    {
        [Required]
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("CPF")]
        [StringLength(11)]
        [Unicode(false)]
        public string Cpf { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "O seu nome não pode ter mais de 50 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "O seu Email não pode ter mais de 100 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime InitialDate { get; private set; } = DateTime.UtcNow; // Define automaticamente como a data atual

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; private set; } = DateTime.UtcNow; // Define automaticamente como a data atual 
    }
}