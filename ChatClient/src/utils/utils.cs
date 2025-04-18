using System.Text.Json;
using models;

namespace utils;

public class Utils
{
    public static string parseToJson(string sender, string payload)
    {
        var message = new Message
        {
            Sender = sender,
            Payload = payload
        };
        return JsonSerializer.Serialize(message);
    }

    public static Message? DeformatterMeesage(string message)
    {
        return JsonSerializer.Deserialize<Message>(message);
    }
}