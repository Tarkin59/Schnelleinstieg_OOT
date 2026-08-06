using System;
using System.IO;
using System.Text.Json;

namespace InventoryService
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(
                "[InventoryService] gestartet...");

            // Ordner überwachen, in den der Broker kopiert
            var watcher =
                new FileSystemWatcher(
                    @"C:\Users\User\Event_Driven\events\inventory",
                    "*.json");

            // Reaktion auf neue Bestellereignisse
            watcher.Created += (s, e) =>
            {
                // JSON-Datei lesen
                var json =
                    File.ReadAllText(e.FullPath);

                // JSON zurück in ein Objekt umwandeln
                var evt =
                    JsonSerializer.Deserialize<OrderCreatedEvent>(json);

                // Bestand aktualisieren (hier nur simuliert)
                Console.WriteLine(
                    $"[Inventory] Bestand aktualisiert");

                Console.WriteLine(
                    $"Artikel: {evt!.Item}");

                Console.WriteLine(
                    $"Menge: {evt.Quantity}");

                Console.WriteLine(
                    $"Bestellung: {evt.OrderId}");
            };

            // Überwachung starten
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Warte auf Bestellereignisse...");

            Console.ReadLine();
        }
    }

    // Gemeinsames Eventmodell
    public class OrderCreatedEvent
    {
        public string OrderId { get; set; } = string.Empty;

        public string Item { get; set; } = string.Empty;

        public int Quantity { get; set; }
    }
}