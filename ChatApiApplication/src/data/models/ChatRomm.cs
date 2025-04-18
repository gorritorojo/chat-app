namespace data.models;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("chat_rooms")]
public class ChatRoom
{

  [Key]
  [Column("id")]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  [Column("name")]
  [Required]
  public string Name { get; set; }

  [Column("messages")]
  [Required]
  public List<Message> Messages { get; set; }

  public ChatRoom() { }
}
