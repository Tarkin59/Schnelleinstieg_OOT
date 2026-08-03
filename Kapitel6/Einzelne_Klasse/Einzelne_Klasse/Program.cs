using System.Security.Claims;

namespace Einzelne_Klasse
{
    internal class Program
    {
        class PKW
        {
        //Eigenschaften
        double laenge;
        int gewicht = 0;
        int sitzplaetze = 5;

        //Methoden

        //Konstruktor
        public PKW(double t_laenge, int t_gewicht, int t_plaetze)
        {

            //Setzen der Eigenschaften
            laenge = t_laenge;
            gewicht = t_gewicht;
            sitzplaetze = t_plaetze;
        }


        //Methode zum beschleunigen
        public void beschleunigen()
        {
            Console.WriteLine("Ich beschleunige!");
        }


        //Methode zum bremsen
        public void bremsen()
        {
            Console.WriteLine("Ich bremse!");
        }
    }


        static void Main(string[] args)
        {
            //Erstellen eines PKW
            PKW my_pkw = new PKW(4.5, 1000, 4);

            //Methoden des PKW nutzen
            my_pkw.beschleunigen();
            my_pkw.bremsen();

            //Warten
            Console.Read();

        }
    }
}
