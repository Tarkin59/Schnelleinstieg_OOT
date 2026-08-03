namespace Interface
{
    //Interface deklarieren
    interface IGeometry
    {
        double flaeche_berechnen();
        double umfang_berechnen();
    }

    class Quadrat : IGeometry
    {
        //Eigene Eigenschaften 
        double Umfang;
        double flaeche;
        double seitenlaenge;

        //Konstruktor
        public Quadrat(double t_seitenlaenge)
        {
            //Zuweisen  der Laenge
            seitenlaenge = t_seitenlaenge;
        }

        //Durch Interface geforderte Methode für Flächenberechnung festlegen
        public double flaeche_berechnen()
        {
            return seitenlaenge * seitenlaenge;
        }

        //Durch Interface geforderte Methode für Umfangberechnung festlegen
        public double umfang_berechnen()
        {
            return 4 * seitenlaenge;
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            //Quadrat-Objekt erzeugen
            Quadrat myQuadrat = new Quadrat(5);

            //Fläche ausgeben
            Console.WriteLine("Fläche: " + myQuadrat.flaeche_berechnen());

            Console.Read();
        }
    }
}
