namespace Einhalten_Liskov
{
    internal class Program
    {
        /// <summary>
        /// Gemeinsame Schnittstelle für geometrische Formen.
        /// Definiert nur die Eigenschaften und Methoden, die wirklich für alle Formen (und deren Flächenberechnung) gelten.
        /// </summary>
        public interface IShape
        {
            /// <summary>
            /// Ruft die berechnete Fläche der Form ab.
            /// </summary>
            int Fläche { get; }
        }

        /// <summary>
        /// Repräsentiert ein Rechteck, das IShape implementiert.
        /// Ein Rechteck hat eine unabhängige Breite und Höhe.
        /// </summary>
        public class Rechteck : IShape
        {
            public int Breite { get; set; }
            public int Höhe { get; set; }

            /// <summary>
            /// Berechnet die Fläche des Rechtecks basierend auf Breite und Höhe.
            /// </summary>
            public int Fläche => Breite * Höhe;
        }

        /// <summary>
        /// Repräsentiert ein Quadrat, das IShape implementiert.
        /// WICHTIG: Ein Quadrat erbt nun NICHT mehr von Rechteck. Dies löst die LSP-Verletzung 
        /// (Liskovsches Substitutionsprinzip) aus dem vorherigen Beispiel.
        /// Ein Quadrat benötigt nur noch eine Seitenlänge und täuscht nicht mehr vor, 
        /// unabhängige Breite und Höhe zu besitzen.
        /// </summary>
        public class Quadrat : IShape
        {
            public int Seitenlänge { get; set; }

            /// <summary>
            /// Berechnet die Fläche des Quadrats.
            /// </summary>
            public int Fläche => Seitenlänge * Seitenlänge;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("--- Korrigiertes Design (LSP eingehalten) ---\n");

            // Test 1: Normales Rechteck
            Rechteck rechteck = new Rechteck { Breite = 5, Höhe = 10 };
            Console.WriteLine($"Rechteck erstellt: Breite = {rechteck.Breite}, Höhe = {rechteck.Höhe}");
            ZeigeFläche(rechteck, "Rechteck");

            Console.WriteLine();

            // Test 2: Quadrat
            // Da es nicht mehr von Rechteck erbt, gibt es keine Verwirrung mehr bezüglich Breite/Höhe.
            Quadrat quadrat = new Quadrat { Seitenlänge = 5 };
            Console.WriteLine($"Quadrat erstellt: Seitenlänge = {quadrat.Seitenlänge}");
            ZeigeFläche(quadrat, "Quadrat");

            Console.WriteLine("\nDrücke eine beliebige Taste zum Beenden...");
            Console.ReadLine();


            /// <summary>
            /// Eine Hilfsmethode, die gegen die Abstraktion (IShape) programmiert ist,
            /// nicht gegen konkrete Klassen wie Rechteck oder Quadrat. 
            /// Dies demonstriert saubere Polymorphie.
            /// </summary>
            static void ZeigeFläche(IShape shape, string formName)
            {
                Console.WriteLine($"-> Die Fläche für das Objekt '{formName}' beträgt: {shape.Fläche}");
            }


            Console.Read();
        }
        
    }
}
