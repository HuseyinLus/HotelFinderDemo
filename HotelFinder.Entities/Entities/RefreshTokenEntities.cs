
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RefreshTokenEntities
    {
        public int Id { get; set; }
        public string? Token { get; set; }
        public DateTime Expires { get; set; }
        public int UserId { get; set; } // Register.Id olacak
        public int? LoginId { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime CreatedAt { get; set; }

        // Burada artık Register tablosuna bağlanıyoruz
        public Register? User { get; set; }
        public Login? Login { get; set; }
    }

}
