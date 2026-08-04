namespace Verletzen_ISP
{
    /// <summary>
    /// Ein "fettes" Interface, das verschiedene Verantwortlichkeiten mischt.
    /// Dies verletzt das Interface Segregation Principle (ISP), da es erzwingt, 
    /// dass Implementierungen Methoden bereitstellen müssen, die sie eventuell gar nicht benötigen.
    /// </summary>
    public interface IMaschine
    {
        void Start();
        void Stop();

        /// <summary>
        /// Diese Methode ergibt nur für bestimmte Maschinen (z.B. Drucker) Sinn.
        /// </summary>
        void Drucken();
    }

    /// <summary>
    /// Für eine Druckmaschine passt das Interface perfekt.
    /// Alle Methoden werden sinnvoll implementiert und genutzt.
    /// </summary>
    public class Druckmaschine : IMaschine
    {
        public void Start() => Console.WriteLine("Druckmaschine: Gerät wird hochgefahren und aufgewärmt.");

        public void Stop() => Console.WriteLine("Druckmaschine: Gerät wird heruntergefahren.");

        public void Drucken() => Console.WriteLine("Druckmaschine: Dokument wird gedruckt...");
    }

    /// <summary>
    /// Für eine Fräsmaschine passt das Interface NICHT.
    /// Sie wird gezwungen, die Methode "Drucken" zu implementieren, obwohl sie diese 
    /// Funktionalität technisch gar nicht unterstützt.
    /// </summary>
    public class Fräsmaschine : IMaschine
    {
        public void Start() => Console.WriteLine("Fräsmaschine: Motor wird gestartet, Sicherheitsprüfung läuft.");

        public void Stop() => Console.WriteLine("Fräsmaschine: Motor wird gestoppt.");

        // --- ISP-Verletzung ---
        // Die Klasse muss diese Methode implementieren, um den Vertrag (IMaschine) zu erfüllen.
        // Die einzige "Lösung" ist es, eine Exception zu werfen oder die Methode leer zu lassen (was beides schlechtes Design ist).
        public void Drucken()
        {
            throw new NotSupportedException("Eine Fräsmaschine kann nicht drucken! (ISP-Verletzung)");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Interface Segregation Principle (ISP) - Verletzung ---\n");

            // Test 1: Druckmaschine (Funktioniert fehlerfrei)
            Console.WriteLine("Test 1: Druckmaschine");
            IMaschine meinDrucker = new Druckmaschine();
            meinDrucker.Start();
            meinDrucker.Drucken();
            meinDrucker.Stop();

            Console.WriteLine("\n----------------------------------------------------\n");

            // Test 2: Fräsmaschine (Führt zum Laufzeitfehler wegen fehlender Funktionalität)
            Console.WriteLine("Test 2: Fräsmaschine");
            IMaschine meineFraese = new Fräsmaschine();
            meineFraese.Start();

            try
            {
                // Ein Entwickler, der nur IMaschine kennt, könnte diese Methode ahnungslos aufrufen.
                // Das Programm stürzt ab oder verhält sich unerwartet.
                meineFraese.Drucken();
            }
            catch (NotSupportedException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"FEHLER BEIM AUFRUF: {ex.Message}");
                Console.ResetColor();
            }

            meineFraese.Stop();

            Console.WriteLine("\nDrücke eine beliebige Taste zum Beenden...");
            Console.ReadLine();
        }
    }
}
