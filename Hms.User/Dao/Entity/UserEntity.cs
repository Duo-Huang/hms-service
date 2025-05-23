using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hms.Common.Dao.Entity;
using Microsoft.EntityFrameworkCore;

namespace Hms.User.Dao.Entity;

[Table("users")]
[Index(nameof(Username), IsUnique = true)]
public class UserEntity : BaseEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [Required ,MaxLength(30)]
    public required string Username { get; set; }

    [Required, MaxLength(30)]
    public required string Password { get; set; }

    [MaxLength(30)] public string? Nickname { get; set; }
}