namespace data.models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

[Table("users")]
[Index(nameof(Username), IsUnique = true)]
public class User
{

  [Key]
  [Column("id")]
  [NotNull]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  [Column("username")]
  [Required]
  public string Username { get; set; }

  [Column("password")]
  [Required]
  public string Password { get; set; }

  public User() { }
}
