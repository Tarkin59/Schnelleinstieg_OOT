namespace Polymorphie
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

        //Methode zum Bremsen, kann in Subklasse überschrieben werden
        public virtual void bremsen()
        {
            Console.WriteLine("Ich bremse!");
        }
    }


    //Subklassen

    //PKW
    //------------------------------------------------
    class PKW : Kraftfahrzeug
    {
        //Eigenschaften 
        int sitzplaetze = 4;
        int Dachlast = 0;

        //Methoden 

        //Konstruktor
        public PKW(double t_laenge, int t_gewicht, int t_plaetze, int t_dlast)
: base(t_laenge, t_gewicht)
        {
            //Setzen der spezialisierten Eigenschaften 
            sitzplaetze = t_plaetze;
            Dachlast = t_dlast;
        }

        //Polymorphe Methode zum Bremsen
        public override void bremsen()
        {
            Console.WriteLine("Der PKW bremst schnell.");
        }
    }

    //LKW
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

        //Polymorphe Methode zum Bremsen
        public override void bremsen()
        {
            Console.WriteLine("Der LKW bremst langsam.");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //LKW erstellen und zum Bremsen bringen
            LKW myLKW = new LKW(12.5, 8000, 20000);
            myLKW.bremsen();

            //PKW erstellen und zum Bremsen bringen
            PKW myPKW = new PKW(4.5, 1500, 5, 100);
            myPKW.bremsen();

            Console.ReadLine();
        }
    }
}
