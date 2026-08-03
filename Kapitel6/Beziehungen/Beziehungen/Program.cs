namespace Beziehungen
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
    class LKW : Kraftfahrzeug
    {
        //Eigenschaften
        int sattellast = 0;

        //Hier schaffen wir Platz für einen Container
        Container my_container = null;

        //Methoden

        //Konstruktor
        public LKW(double t_laenge, int t_gewicht, int t_slast) : base(t_laenge, t_gewicht)
        {
            //Setzen der spezifischen Eigenschaften
            sattellast = t_slast;
        }

        //Methoden
        //Hier wird der Container dem LKW zugewisen
        public void beladen_mit_Container(Container t_container)
        {
            Console.WriteLine("Lade Container");
            //Zuweisen zu interner Eigenschaft
            my_container = t_container;
        }

        //Methode zur aktuellen Beladung  des LKW
        public void zeige_container()
        {
            Console.WriteLine("Container hat geladen " + my_container.gib_inhalt_aus());
        }
    }



    //Klasse Container
    class Container
    {
        //Eigenschaften
        string besitzer;
        int gewicht = 0;
        string inhalt;

        //Methoden

        //Konstruktor
        public Container(string t_besitzer, int t_gewicht, string t_inhalt)
        {
            //Setzen der Eigenschaften
            besitzer = t_besitzer;
            gewicht = t_gewicht;
            inhalt = t_inhalt;
        }

        //Methode zum Einrasten
        public void einrasten()
        {
            Console.WriteLine("Container rastet ein");
        }


        //Methode zum Ausgeben des Inhaltes
        public string gib_inhalt_aus()
        {
            return inhalt;
        }
    }




    internal class Program
    {
        static void Main(string[] args)
        {
            //LKW definieren
            LKW my_LKW = new LKW(5.2, 1000, 40);

            //Methoden nutzen
            my_LKW.beschleunigen();
            my_LKW.bremsen();

            //mit Container beladen

            //Container definieren
            Container my_container = new Container("MAESK", 40, "Elektronik");

            //Und nun den LKW beladen
            my_LKW.beladen_mit_Container(my_container);

        }
    }
}
