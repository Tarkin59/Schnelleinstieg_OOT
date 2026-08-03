namespace Vererbung
{

    //Basisklasse
    abstract class Kraftfahrzeug
    {
        //Eigenschaften
        double laenge;
        int gewicht = 0;


        //Methoden

        //Konstruktor
        public Kraftfahrzeug(double t_laenge, int t_gewicht)
        {
            //Setzen der Eigenschaften
            laenge = t_laenge;
            gewicht = t_gewicht;
        }

        //Methode zum Beschleunigen
        public void beschleunigen()
        {
            Console.WriteLine("Ich beschleunige!");
        }

        //Methode zum Bremsen
        public void bremsen()
        {
            Console.WriteLine("Ich bremse!");
        }
    }

    //Subklassen

    //PKW
    //-------------------------------------------------------------------
    class PKW : Kraftfahrzeug
    {
        //Eigenschaften
        int sitzplaetze = 4;
        int Dachlast = 0;

        //Methoden

        //Konstruktor
        public PKW(double t_laenge, int t_gewicht, int t_plaetze, int t_dlast) : base(t_laenge, t_gewicht)
        {
            //Setzen der spezialisierten Eigenschaften
            sitzplaetze = t_plaetze;
            Dachlast = t_dlast;
        }

        //Methoden
        public void oeffne_heckklappe()
        {
            Console.WriteLine("Oeffne Heckklappe");
        }
    }


    //LKW
    //--------------------------------------------------------------
    class LKW : Kraftfahrzeug
    {
        //Eigenschaften
        int sattellast = 0;

        //Methoden

        //Konstruktor
        public LKW(double t_laenge, int t_gewicht, int t_slast) :
        base(t_laenge, t_gewicht)
        {
            //Setzen der spezialisierten Eigenschaften
            sattellast = t_slast;
        }

        //Methoden
        public void beladen_mit_Container()
        {

            //LKW beladen
            Console.WriteLine("LKW wird mit Container beladen!");

        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //LKW -Objekt erzeugen
            LKW my_lkw = new LKW(12.5, 8000, 20000);

            //LKW mit Container beladen (Dummy)
            my_lkw.beladen_mit_Container();

            //Warten
            Console.ReadLine();

        }
    }
}
