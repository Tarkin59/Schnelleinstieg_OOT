namespace Verletzen_SRP
{

    public class Report
    {
        public void GenerateReport(List<string> data)
        {
            //Hier wird das SRP verletzt, da die Methode GenerateReport mehrere Verantwortlichkeiten hat:
            //Daten verarbeiten, Bericht speichern und Bericht anzeigen.

            // Daten verarbeiten
            var processed = data.Select(d => d.ToUpper()).ToList();

            // Bericht speichern
            File.WriteAllLines("report.txt", processed);

            // Bericht anzeigen
            foreach (var line in processed)
            {
                Console.WriteLine(line);
            }
        }
    }

        internal class Program
    {
        static void Main(string[] args)
        {
                List<string> sampleData = new List<string>
                {
                        "das ist die erste zeile",
                        "hier stehen wichtige informationen",
                        "ende des berichts"
                };

                // 2. Report-Objekt instanziieren
                Report myReport = new Report();

                // 3. Methode aufrufen
                Console.WriteLine("--- Ausgabe auf der Konsole ---");
                myReport.GenerateReport(sampleData);

                Console.WriteLine("\nDer Bericht wurde erfolgreich generiert und in der Datei 'report.txt' gespeichert.");

                Console.Read();
            }
    }
}
