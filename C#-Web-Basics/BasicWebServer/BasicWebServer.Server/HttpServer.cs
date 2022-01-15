using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BasicWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;

        public HttpServer(string _ipAddress, int _port)
        {
            ipAddress = IPAddress.Parse(_ipAddress);
            port = _port;

            serverListener = new TcpListener(ipAddress, port);
        }

        public void Start()
        {
            serverListener.Start();

            Console.WriteLine($"Server started on port {port}.");
            Console.WriteLine($"Listening for request...");

            while (true)
            {
                var connection = serverListener.AcceptTcpClient();

                var networkStream = connection.GetStream();

                var requestText = ReadRequest(networkStream);

                Console.WriteLine(requestText);

                WriteResponse(networkStream, "Server Works!");
                
                connection.Close();
            }
        }

        private void WriteResponse(NetworkStream networkStream, string msg)
        {
            var contentLength = Encoding.UTF8.GetByteCount(msg);

            var response = $@"HTTP/1.1 200 OK
Content-Type: text/plain; charset=UTF-8
Content-Length: {contentLength}

{msg}";

            var responseBytes = Encoding.UTF8.GetBytes(response);
            networkStream.Write(responseBytes);
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var totalBytes = 0;

            var requestBuilder = new StringBuilder();

            do
            {
                var bytesRead = networkStream.Read(buffer, 0, bufferLength);
                totalBytes += bytesRead;

                if (totalBytes >= 10 * 1024)
                {
                    throw new InvalidOperationException("Request is to long!");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
 
            } while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }
    }
}
