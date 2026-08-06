using System;
using System.IO;
using System.Text.Json;

namespace ShippingService
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(
                "[ShippingService] gestartet...");

            // Ordner überwachen
            var watcher =
                new FileSystemWatcher(
                    @"C:\Users\User\Event_Driven\events\shipping",
                    "*.json");

            // Ereignisbehandlung
            watcher.Created += (s, e) =>
            {
                // JSON-Datei einlesen
                var json =
                    File.ReadAllText(e.FullPath);

                // JSON in Objekt umwandeln
                var evt =
                    JsonSerializer.Deserialize<OrderCreatedEvent>(json);

                // Versandprozess simulieren
                Console.WriteLine(
                    "[Shipping] Versand vorbereitet");

                Console.WriteLine(
                    $"Artikel: {evt!.Item}");

                Console.WriteLine(
                    $"Menge: {evt.Quantity}");

                Console.WriteLine(
                    $"Bestellnummer: {evt.OrderId}");
            };

            // Dateisystemüberwachung aktivieren
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Warte auf Versandaufträge...");

            Console.ReadLine();
        }
    }

    // Eventklasse
    public class OrderCreatedEvent
    {
        public string OrderId { get; set; } = string.Empty;

        public string Item { get; set; } = string.Empty;

        public int Quantity { get; set; }
    }
}