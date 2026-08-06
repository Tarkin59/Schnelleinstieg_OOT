
using System;
using System.IO;
using System.Text.Json;

namespace OrderService
{
    class Program
    {
        static void Main()
        {
            // Absoluter Pfad - bitte bei Bedarf anpassen
            var incomingPath = @"C:\Users\User\Event_Driven\events\incoming";

            // Ordner sicherstellen
            Directory.CreateDirectory(incomingPath);

            Console.WriteLine("[OrderService] gestartet...");
            Console.WriteLine($"Events werden geschrieben nach: {incomingPath}");
            Console.WriteLine();

            while (true)
            {
                Console.Write("Artikel: ");
                var item = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(item))
                {
                    Console.WriteLine("Artikel darf nicht leer sein.");
                    continue;
                }

                Console.Write("Menge: ");
                var qtyInput = Console.ReadLine();

                if (!int.TryParse(qtyInput, out int qty))
                {
                    Console.WriteLine("Bitte eine gültige Zahl eingeben.");
                    continue;
                }

                var evt = new OrderCreatedEvent
                {
                    OrderId = Guid.NewGuid().ToString(),
                    Item = item,
                    Quantity = qty
                };

                var json = JsonSerializer.Serialize(evt, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                var filename = Path.Combine(incomingPath, $"order_{evt.OrderId}.json");

                File.WriteAllText(filename, json);

                Console.WriteLine($"[OrderService] Event erzeugt: {filename}");
                Console.WriteLine();
            }
        }
    }

    class OrderCreatedEvent
    {
        public string OrderId { get; set; } = string.Empty;
        public string Item { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
