using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hms.Common.Dao.Entity;

public class BaseEntity
{
    [Required]
    [Column(TypeName = "timestamp")]
    // [[DatabaseGenerated(DatabaseGeneratedOption.Identity)]] == ValueGeneratedOnAdd
    public DateTime CreatedAt { get; set; }

    [Required]
    [Column(TypeName = "timestamp")]
    // [DatabaseGenerated(DatabaseGeneratedOption.Computed)] == ValueGeneratedOnAddOrUpdate
    public DateTime UpdatedAt { get; set; }
}