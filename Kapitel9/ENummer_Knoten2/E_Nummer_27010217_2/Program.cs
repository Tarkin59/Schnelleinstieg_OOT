using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;

namespace E_Nummer_27010217_2
{
    //Region, welche als SystemContract definiert îst
    [ServiceContract]
    public interface IAbfrage
    {
        [OperationContract]
        string Auslesen(int A);
    }

    //Benutzbare Klasse, welche den ServiceContract erbt
    public class E_Nummer : IAbfrage
    {
        //Eigenschaften
        List<string> My_Inhalte = new List<string>();

        public string Auslesen(int t_Nummer)
        {
            My_Inhalte.Add("C");
            My_Inhalte.Add("D");

            //wenn 3 --> C
            if (t_Nummer == 3)
            {
                return My_Inhalte[0];
            }
            //wenn 4--> D
            else if (t_Nummer == 4)
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

            Console.Read();
        }
    }
}
