
using System.ComponentModel;

public class Program
{
  public static async Task Main()
  {
    MqttClient client = new MqttClient();
    await client.Connect();
    new Thread(async () => await client.SubscribeTopic("brayan_julieta")).Start();

    Console.ReadLine();
  }


}