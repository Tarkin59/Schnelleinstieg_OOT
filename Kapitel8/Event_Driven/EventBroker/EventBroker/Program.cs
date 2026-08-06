using System;
using System.IO;

namespace EventBroker
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("[EventBroker] gestartet...");

            // Überwacht den Incoming-Ordner auf neue JSON-Dateien
            var watcher =
                new FileSystemWatcher(
                    @"C:\Users\User\Event_Driven\events\incoming",
                    "*.json");

            // Wird ausgeführt sobald eine neue Datei erscheint
            watcher.Created += (s, e) =>
            {
                Console.WriteLine(
                    $"[Broker] Neues Event empfangen: {e.Name}");

                // Zielordner InventoryService
                var inventoryTarget =
                    Path.Combine(
                       @"C:\Users\User\Event_Driven\events\inventory",
                        e.Name!);

                // Datei an InventoryService weiterleiten
                File.Copy(
                    e.FullPath,
                    inventoryTarget,
                    overwrite: true);

                Console.WriteLine(
                    "[Broker] An Inventory weitergeleitet");

                // Zielordner ShippingService
                var shippingTarget =
                    Path.Combine(
                        @"C:\Users\User\Event_Driven\events\shipping",
                        e.Name!);

                // Datei an ShippingService weiterleiten
                File.Copy(
                    e.FullPath,
                    shippingTarget,
                    overwrite: true);

                Console.WriteLine(
                    "[Broker] An Shipping weitergeleitet");
            };

            // Überwachung aktivieren
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Broker wartet auf Ereignisse...");

            // Programm offen halten
            Console.ReadLine();
        }
    }
}