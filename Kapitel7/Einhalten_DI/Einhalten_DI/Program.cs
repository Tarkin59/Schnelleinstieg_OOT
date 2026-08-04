namespace Einhalten_DI
{
    /// <summary>
    /// Definition eines Interface -> Grundlage der losen Kopplung (Abstraktion).
    /// Sowohl das High-Level-Modul (BerichtService) als auch das Low-Level-Modul (Drucker) 
    /// hängen nun von dieser Abstraktion ab.
    /// </summary>
    public interface IDrucker
    {
        void Drucken(string text);
    }

    /// <summary>
    /// Konkrete Implementierung des Interfaces für einen Standard-Drucker.
    /// </summary>
    public class Drucker : IDrucker
    {
        public void Drucken(string text) => Console.WriteLine($"[Standard-Drucker]: {text}");
    }

    /// <summary>
    /// ZUSATZ: Eine weitere Implementierung, um die neu gewonnene Flexibilität zu demonstrieren.
    /// </summary>
    public class PdfDrucker : IDrucker
    {
        public void Drucken(string text) => Console.WriteLine($"[PDF-Drucker]: Speichere '{text}' als PDF-Datei ab.");
    }

    /// <summary>
    /// High-Level-Modul: Enthält die Geschäftslogik.
    /// Es kennt keine konkreten Drucker-Klassen mehr, sondern nur noch das Interface IDrucker.
    /// </summary>
    public class BerichtService
    {
        // Abhängigkeit zur Abstraktion mittels loser Kopplung
        private readonly IDrucker _drucker;

        /// <summary>
        /// Constructor Injection (Konstruktor-Injektion):
        /// Das konkrete Drucker-Objekt wird von außen "hineingereicht".
        /// Der BerichtService muss nicht mehr mit "new" selbst ein Objekt erstellen.
        /// </summary>
        public BerichtService(IDrucker drucker)
        {
            _drucker = drucker;
        }

        public void ErstelleBericht()
        {
            Console.WriteLine("BerichtService: Sammle Daten und formatiere den Bericht...");
            _drucker.Drucken("Bericht erstellt");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Dependency Inversion Principle (DIP) - Korrigiert ---\n");

            // --- Szenario 1: Nutzung mit dem normalen Drucker ---
            Console.WriteLine("Szenario 1: Ausgabe auf dem normalen Drucker");
            // Wir erstellen das konkrete Low-Level-Objekt...
            IDrucker normalerDrucker = new Drucker();
            // ... und übergeben es an das High-Level-Objekt.
            BerichtService service1 = new BerichtService(normalerDrucker);
            service1.ErstelleBericht();

            Console.WriteLine("\n----------------------------------------------------\n");

            // --- Szenario 2: Nutzung mit dem PDF-Drucker ---
            Console.WriteLine("Szenario 2: Ausgabe als PDF");
            // Wir können das Verhalten des BerichtService nun komplett ändern, 
            // OHNE den Code in der Klasse BerichtService auch nur anzufassen!
            IDrucker pdfDrucker = new PdfDrucker();
            BerichtService service2 = new BerichtService(pdfDrucker);
            service2.ErstelleBericht();

            Console.WriteLine("\nDrücke eine beliebige Taste zum Beenden...");
            Console.ReadLine();
        }
    }
}
