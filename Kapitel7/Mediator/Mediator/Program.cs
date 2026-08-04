using System;
using System.Collections.Generic;

namespace Mediator_simpel
{
    //Die Mediatorklasse
    class Mediator
    {
        List<Teilnehmer> my_part = new List<Teilnehmer>();

        
        //Methode zum Anhängen eines Panels
        public void add_part(Teilnehmer p)
        {
            my_part.Add(p);
        }

        // Realisation einer Broadcast- Methode
        public void Send(string message, Teilnehmer my_participant)
        {
            //Wie viele Teilnehmer sind vorhanden
            int anz_part = my_part.Count;
            Teilnehmer my_p;

            //Übermittlung an alle
            for (int i = 0; i < anz_part; i++)
            {
                my_p = my_part[i];

                //aber nicht an den Teilnehmer, welcher die Nachricht gesendet hat
                if (my_p.ausgeben_name() != my_participant.ausgeben_name())
                {
                    Console.WriteLine(my_p.ausgeben_name() + " --> " + my_p.ausgeben(message));
                }
            }
        }
    }

    class Teilnehmer
    {
        //Mediator instantiieren
        Mediator m = new Mediator();
        string name;

        public Teilnehmer(Mediator t_mediator, string t_name)
        {
            //Instanz des Mediators zuweisen
            m = t_mediator;
            name = t_name;
        }

        //Aufrufen des Senden des Mediators
        public void send(string message)
        {
            m.Send(message, this);
        }

        //Ausgabemethode des Teilnehmers
        public string ausgeben(string message)
        {
            return "Mediator hat weitergeleitet: " + message;
        }

        //Rückgabe des Namens des Teilnehmers
        public string ausgeben_name()
        {
            return name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Mediator instantiieren
            Mediator m = new Mediator();

            //Panel instantiieren
            Teilnehmer my_p1 = new Teilnehmer(m, "erster");
            //und anhängen
            m.add_part(my_p1);

            //Panel instantiieren
            Teilnehmer my_p2 = new Teilnehmer(m, "zweiter");
            //und anhängen
            m.add_part(my_p2);

            //Panel instantiieren
            Teilnehmer my_p3 = new Teilnehmer  (m, "dritter");
            //und anhängen
            m.add_part(my_p3);

            //------------------------------------------------

            //Senden einer Nachricht von Teilnehmer 2 an die übrigen Teilnehmer
            my_p2.send("Hallo");

            Console.ReadLine();
        }
    }


    
}


