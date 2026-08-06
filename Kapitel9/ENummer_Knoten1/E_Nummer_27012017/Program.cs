/*
Knoten zu E-Nummerbeispiel

C. Herren
27.01.2023

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Zubinden des Servicemodels
using System.ServiceModel;

namespace E_Nummer_27012017
{
    //Region, welche als SystemContract definiert îst
    [ServiceContract]
    public interface IAbfrage
    {
        [OperationContract]
        string Auslesen(int A);
    }

    //Benutzbare Klasse, welche den ServiceContract erbt
    public class E_Nummer:IAbfrage 
    {
        //Eigenschaften
        List<string> My_Inhalte = new List<string>();
        
        public string Auslesen(int t_Nummer)
        {
            //Repository laden
            My_Inhalte.Add("A");
            My_Inhalte.Add("B");

            //Wenn 1 --> A
            if (t_Nummer == 1)
            {
                return My_Inhalte[0];
            }
            //wenn 2 --> B
            else if (t_Nummer==2)
            {
                return My_Inhalte[1];
            }
            else
            {
                return "NA";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Definition des Servicehost --> mit Klasse Calculate verbunden
            ServiceHost calcService = new ServiceHost(typeof(E_Nummer));

            //try
            //{ //Physisches Öffnen
            calcService.Open();
            Console.WriteLine("Service is up and running… Press return to terminate.");
            //verhindert das Schliessen des Servicehost 

            //Aufsetzen Client ...

            //Verbindung (Channel) erzeugen
            ChannelFactory<IAbfrage> factory = new ChannelFactory<IAbfrage>(new WSHttpBinding(), new EndpointAddress("http://localhost:2310/E_Nummer"));
            IAbfrage channel = factory.CreateChannel();

            //Verbindung (Channel) zu 2ten Knoten erzeugen
            ChannelFactory<IAbfrage> factory_1 = new ChannelFactory<IAbfrage>(new WSHttpBinding(), new EndpointAddress("http://localhost:2311/E_Nummer"));
            IAbfrage channel_1 = factory_1.CreateChannel();


            //Auslesen Dummy
            while (true)
            {
                Console.WriteLine("Geben Sie eine Nummer ein");
                string eingabe = Console.ReadLine();
                int E_Nummer = Convert.ToInt32(eingabe);

                //Auslesen via den Kanal auf den eigenen Knoten
                string ausgabe = channel.Auslesen(E_Nummer);

                //simpel gestrikt
                if (ausgabe == "NA")
                {
                    //Zugriff auf Kanal zu 2. Knoten
                    Console.WriteLine(channel_1.Auslesen(E_Nummer));
                }
                else
                {
                    Console.WriteLine(ausgabe);
                }
            }
            
            Console.ReadLine();

        }
    }
}
