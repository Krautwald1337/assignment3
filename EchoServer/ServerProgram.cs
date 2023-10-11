using System.Net;
using System.Net.Sockets;
using System.Text;

var port = 5000;

var server = new TcpListener(IPAddress.Loopback, port);
server.Start();

Console.WriteLine("Server started");

while(true)
{
    var client = server.AcceptTcpClient();
    Console.WriteLine("Client connected");

    var stream = client.GetStream();

    var buffer = new byte[1024];
    var readCnt = stream.Read(buffer);

    var request = Encoding.UTF8.GetString(buffer, 0, readCnt);

    Console.WriteLine($"Request: {request}");

    var response = request.ToUpper();

    stream.Write(Encoding.UTF8.GetBytes(response));

}
