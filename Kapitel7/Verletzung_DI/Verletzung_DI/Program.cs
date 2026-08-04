namespace Verletzung_DI
{
    /// <summary>
    /// Die Klasse Drucker repräsentiert ein konkretes Low-Level-Modul.
    /// Sie ist für die physische (oder in diesem Fall konsolenbasierte) Ausgabe zuständig.
    /// </summary>
    public class Drucker
    {
        public void Drucken(string text) => Console.WriteLine($"[Drucker] {text}");
    }

    /// <summary>
    /// Die Klasse BerichtService repräsentiert ein High-Level-Modul, das die Geschäftslogik enthält.
    /// HIER LIEGT DIE VERLETZUNG DES DIP VOR: 
    /// Das Dependency Inversion Principle besagt, dass High-Level-Module nicht 
    /// von konkreten Low-Level-Modulen abhängen sollten. Beide sollten von Abstraktionen (Interfaces) abhängen.
    /// </summary>
    public class BerichtService
    {
        // Direkte Abhängigkeit von einer konkreten Klasse -> Verletzung des DIP!
        // Das "new"-Schlüsselwort bindet den BerichtService untrennbar an diesen speziellen Drucker.
        // Ein Austausch (z.B. gegen einen PdfDrucker, einen Netzwerkdrucker oder ein Mock-Objekt für Unit-Tests) 
        // ist ohne Änderung am Code dieser Klasse unmöglich.
        private readonly Drucker _drucker = new Drucker();

        public void ErstelleBericht()
        {
            Console.WriteLine("BerichtService: Sammle Daten und formatiere den Bericht...");
            _drucker.Drucken("Bericht erstellt (Fest verdrahteter Ausdruck)");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Dependency Inversion Principle (DIP) - Verletzung ---\n");

            // Wir erstellen den Service. Da der Drucker im Inneren der Klasse hartverdrahtet ist,
            // haben wir von außen (als Aufrufer) keine Möglichkeit, das Druckverhalten zu steuern oder zu ändern.
            BerichtService service = new BerichtService();

            // Führt den Bericht aus und nutzt unweigerlich den fest verdrahteten Standarddrucker.
            service.ErstelleBericht();

            Console.WriteLine("\nDrücke eine beliebige Taste zum Beenden...");
            Console.ReadLine();
        }
    }
}
