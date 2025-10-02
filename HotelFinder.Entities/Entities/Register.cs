using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Register
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public int Id { get; set; }

    [StringLength(50)]
    [Required]
    public string? Name { get; set; }

    [StringLength(50)]
    [Required]
    public string? LastName { get; set; }

    [StringLength(50)]
    [Required]
    public string? Username { get; set; }

    [StringLength(50)]
    [Required]
    public string? Password { get; set; }

    [StringLength(40)]
    [Required]
    public string? Email { get; set; }

    [StringLength(50)]
    [Required]
    public string? Location { get; set; }

    [StringLength(20)]
    [Required]
    public string Role { get; set; } = "User";

    // 👇 RefreshToken ilişkisinin navigation property’si
    public ICollection<RefreshTokenEntities> RefreshTokens { get; set; } = new List<RefreshTokenEntities>();
}
