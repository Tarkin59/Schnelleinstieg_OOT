namespace Verletzen_Liskov
{
    /// <summary>
    /// Die Basisklasse für ein Rechteck.
    /// Sie definiert den "Vertrag", dass Breite und Höhe unabhängig voneinander 
    /// gesetzt werden können.
    /// </summary>
    public class Rechteck
    {
        // virtual erlaubt es abgeleiteten Klassen, das Verhalten beim Setzen/Abrufen zu ändern
        public virtual int Breite { get; set; }
        public virtual int Höhe { get; set; }

        /// <summary>
        /// Berechnet die Fläche des Rechtecks basierend auf der aktuellen Breite und Höhe.
        /// </summary>
        public int Fläche => Breite * Höhe;
    }

    /// <summary>
    /// Repräsentiert ein Quadrat, erbt von Rechteck.
    /// Dies ist das klassische Beispiel für eine Verletzung des Liskovschen Substitutionsprinzips (LSP).
    /// Mathematisch ist ein Quadrat ein Rechteck, aber im Code bricht das Quadrat hier 
    /// das erwartete Verhalten der Rechteck-Klasse (unabhängige Seiten).
    /// </summary>
    public class Quadrat : Rechteck
    {
        public override int Breite
        {
            // Ein expliziter Getter ist in C# zwingend erforderlich, 
            // wenn eine Auto-Property der Basisklasse überschrieben wird.
            get { return base.Breite; }
            set
            {
                base.Breite = value;
                // Seiteneffekt: Die Höhe wird heimlich mitgeändert, 
                // um die Eigenschaft eines Quadrats zu bewahren.
                base.Höhe = value;
            }
        }

        public override int Höhe
        {
            get { return base.Höhe; }
            set
            {
                base.Höhe = value;
                // Seiteneffekt: Die Breite wird heimlich mitgeändert.
                base.Breite = value;
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Test 1: Verhalten eines normalen Rechtecks ---");

            Rechteck normalesRechteck = new Rechteck();
            normalesRechteck.Breite = 5;
            normalesRechteck.Höhe = 10;

            Console.WriteLine($"Parameter: Breite = {normalesRechteck.Breite}, Höhe = {normalesRechteck.Höhe}");
            // Funktioniert wie erwartet: 5 * 10 = 50
            Console.WriteLine($"Erwartete Fläche: 50 | Berechnete Fläche: {normalesRechteck.Fläche}\n");


            Console.WriteLine("--- Test 2: Verhalten des Quadrats (LSP-Verletzung) ---");

            // Das Liskovsche Substitutionsprinzip besagt: Wir sollten in der Lage sein, 
            // ein Objekt der abgeleiteten Klasse (Quadrat) überall dort einzusetzen, 
            // wo ein Objekt der Basisklasse (Rechteck) erwartet wird, ohne dass Fehler entstehen.

            Rechteck meinQuadrat = new Quadrat();

            // Ein Entwickler, der nur die Basisklasse (Rechteck) kennt, geht davon aus, 
            // dass die folgende Zuweisung zu einer Fläche von 50 führt.
            meinQuadrat.Breite = 5;
            meinQuadrat.Höhe = 10; // Hier überschreibt die Quadrat-Logik die Breite wieder auf 10!

            Console.WriteLine($"Parameter: Breite = {meinQuadrat.Breite}, Höhe = {meinQuadrat.Höhe}");
            // Schlägt fehl: Die Fläche ist 100 statt 50, weil die Breite durch das Setzen der Höhe verändert wurde.
            Console.WriteLine($"Erwartete Fläche: 50 | Berechnete Fläche: {meinQuadrat.Fläche}");

            Console.WriteLine("\nDrücke eine beliebige Taste zum Beenden...");
            Console.ReadLine();
        

        Console.Read();
        }
    }
}
