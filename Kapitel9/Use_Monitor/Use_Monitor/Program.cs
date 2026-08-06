using System;

//zusätzliche Namespaces
using System.Threading;
using System.Diagnostics;

namespace Use_Monitor
{
    class Program
    {
        //Eigenschaften
         static int summe = 0;

        //Internes lock Objekt
        static object locker = new object();

        //Methode des Threads A
        static public void BerechneMonitorA(object anzahl)
        {         
            for (int i = 0; i < 10; i++)
            {
                //Thread macht 100 ms nichts
                Thread.Sleep(100);
                //---------------------------------------------
                //Kritischer Abschnitt startet
                Monitor.Enter(locker);

                //Hochzählen
                summe += (int)anzahl;
                //Nach 5 Durchläufen wird Thread a schlafen gelegt (wartet auf Pulse)
                if (i == 3) Monitor.Wait(locker);
                //Ausgabe
                Console.WriteLine("Thread {0}: i = {1} Summe = {2}", Thread.CurrentThread.Name,i, summe);
                Monitor.Exit(locker);
                //Kritischer Abschnitt endet
                //---------------------------------------------
        }
    }

        //Methode des Threads B
        static public void BerechneMonitorB(object anzahl)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                //----------------------------------------------------
                //Starten des kritischen Abschnitts
                Monitor.Enter(locker);
                //Dekremntieren
                summe -= (int)anzahl;
                //Nach 8 Durchläufen wird der Wettbewerb wieder eröffnet
                if (i == 7) Monitor.Pulse(locker);
                Console.WriteLine("Thread {0}: i = {1} Summe = {2}", Thread.CurrentThread.Name,i, summe);
                Monitor.Exit(locker);
                //----------------------------------------------------------
            }
        }

        static void Main(string[] args)
        {
            //Instantiieren der Threads
            Thread A = new Thread(BerechneMonitorA);
            A.Name = "a";
            A.Start(1);

            Thread B = new Thread(BerechneMonitorB);
            B.Name = "b";
            B.Start(1);

            Console.Read();

        }
    }
}
