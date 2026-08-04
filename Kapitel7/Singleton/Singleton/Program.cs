using System;


namespace Singleton_pattern
{
    //Klassendefinition zu Singleton Pattern
    class Singleton
    {
        //Instanz der Klasse
        private static Singleton _instance;

        //Konstruktor -> Hier nicht public sondern private
        private Singleton()
        {
            //Hier leer, da nur Schulbeispiel
        }

        //Herzstück des Pattern, der «Ersatzkonstruktor»
        public static Singleton Instance()
        {
            //Überprüfen, ob schon eine Instanz besteht
            if (_instance == null)
            {
                //Wenn nein --> erzeugen
                _instance = new Singleton();
            }
            return _instance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Instanziierung über die Instance-Methode,
            //da Konstruktor = private
            //Singleton my_s = new Singleton();  aufgrund Sicherheitsebene private //nicht möglich

            //Erster Zugriff
            Singleton s1 = Singleton.Instance();
            //Versuch 2te Instanzen zu schaffen
            Singleton s2 = Singleton.Instance();

            //Test auf gleiche Instanz
            if (s1 == s2)
            {
                Console.WriteLine("Dieselbe Instanz gefunden");
            }

            //Warten
            Console.ReadKey();
        }
    }
}

