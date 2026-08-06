
using System.Text;
using System.Net.Sockets;
using System.Text.Json;
using SharedModel;
using static SharedModel.Product;
using static SharedModel.Order;


namespace OrderClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OrderService gestartet...");

            // Verbindung zum ProductService
            var client = new TcpClient("localhost", 5000);
            var stream = client.GetStream();

            // Produkt-ID senden
            int productId = 1;
            byte[] requestBytes = Encoding.UTF8.GetBytes(productId.ToString());
            stream.Write(requestBytes, 0, requestBytes.Length);
            Console.WriteLine($"Produktanfrage gesendet: {productId}");

            // Antwort lesen
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string json = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Antwort erhalten: {json}");


            // JSON in Produktobjekt deserialisieren
            var product = JsonSerializer.Deserialize<Product>(json);
            if (product?.Name == null)
            {
                Console.WriteLine("Produkt nicht gefunden.");
                return;
            }
            // Bestellung vorbereiten und erzeugen
            Guid OrderId = Guid.NewGuid();
            string ProductName = product.Name;
            decimal Price = product.Price;
            DateTime CreatedAt = DateTime.UtcNow;


            var order = new Order(OrderId, ProductName, Price, CreatedAt);

            Console.WriteLine("\nBestellung erstellt:");
            Console.WriteLine($"OrderId: {order.OrderId}");
            Console.WriteLine($"Produkt: {order.ProductName}");
            Console.WriteLine($"Preis: {order.Price}");

        }
    }
}

