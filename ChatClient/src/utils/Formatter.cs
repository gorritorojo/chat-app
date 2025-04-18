using System.Text;
using models;

namespace utils;

public class Formatter
{
    public static Func<byte[], Message?> getData = (input) => Utils.DeformatterMeesage(Encoding.UTF8.GetString(input));

    public static void formatPrintSendMessage(byte[] inputMessage)
    {
        Message? message = getData(inputMessage);
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("\u001b[31m" + message.Sender + " >>  " + "\u001b[37m" + message.Payload);
        Console.ResetColor();
    }
    public static void formatPrintReceiveMessage(byte[] inputMessage)
    {
        Message? message = getData(inputMessage);
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("\u001b[32m" + message?.Sender + " >> " + "\u001b[37m" + message?.Payload);
        Console.ResetColor();
    }

}