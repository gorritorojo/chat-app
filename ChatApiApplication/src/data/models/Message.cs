using System.ComponentModel.DataAnnotations.Schema;

namespace data.models;


[Table("messages")]
public class Message
{
  public int Id { get; set; }
  public int UserId { get; set; }
  public User User { get; set; }
  public int ChatRoomId { get; set; }
  public ChatRoom ChatRoom { get; set; }
  public string Content { get; set; }
  public DateTime Timestamp { get; set; }

  public Message() { }
}
