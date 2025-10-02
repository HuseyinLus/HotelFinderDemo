﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Login
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId   { get; set; }

        [StringLength(50)]
        [Required]
        public string? UserName { get; set; }

        [StringLength(50)]
        [Required]
        public string? Password { get; set; }

        public ICollection<RefreshTokenEntities>? RefreshTokens { get; set; } // Kullanicinin sahip oldugu tokenler

    }
}
