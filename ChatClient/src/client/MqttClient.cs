using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using utils;

public class MqttClient
{

  private readonly string brokerUrl = "localhost";
  private readonly int port = 1883;
  private readonly string clientId = "client";
  private readonly string MqttUser = "luna";
  private readonly string MqttPassword = "password123";


  private IMqttClient? _client;



  public async Task Connect()
  {
    var options = new MqttClientOptionsBuilder().WithTcpServer(server: brokerUrl, port).WithClientId(clientId).WithCleanSession().Build();
    var factory = new MqttFactory();
    var client = factory.CreateMqttClient();

    client.UseApplicationMessageReceivedHandler(e => Formatter.formatPrintReceiveMessage(e.ApplicationMessage.Payload));

    client.UseConnectedHandler(e =>
    {
      Console.Clear();
      Console.WriteLine("conectao");
    });
    _client = client;
    await client.ConnectAsync(options);
  }


  public async Task SubscribeTopic(string topic)
  {
    if ((_client == null) || (_client.IsConnected == false))
      return;

    await _client.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).Build());
  }

  public void Disconnect()
  {
    _client?.DisconnectAsync();
    _client?.Dispose();
    _client = null;
  }

  public void SendMessage(string username, string payload)
  {
    if ((_client == null) || (_client.IsConnected == false))
      return;

    string message = Utils.parseToJson(username, payload);

  }

}
