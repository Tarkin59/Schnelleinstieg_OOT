
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace Product_Service
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Die lokale Datenbank der Produkte
            var products = new Dictionary<int, (string Name, decimal Price)>
            {
                { 1, ("Laptop", 1200m) },
                { 2, ("Monitor", 300m) }
            };

            //Aufbau eines einfachen TCP-Servers
            var listener = new TcpListener(IPAddress.Loopback, 5000);
            listener.Start();
            Console.WriteLine("ProductService läuft auf Port 5000...");

            while (true)
            {
                var client = listener.AcceptTcpClient();
                var stream = client.GetStream();

                // Anfrage lesen und umwandeln
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Anfrage erhalten: {request}");

                if (int.TryParse(request, out int productId) && products.TryGetValue(productId, out var p))
                {
                    var response = new
                    {
                        Id = productId,
                        Name = p.Name,
                        Price = p.Price
                    };
                    string json = JsonSerializer.Serialize(response);
                    byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
                    stream.Write(jsonBytes, 0, jsonBytes.Length);
                }
                else
                {
                    string error = "{\"error\":\"Produkt nicht gefunden\"}";
                    byte[] errorBytes = Encoding.UTF8.GetBytes(error);
                    stream.Write(errorBytes, 0, errorBytes.Length);
                }
            }
        }
    }
}
