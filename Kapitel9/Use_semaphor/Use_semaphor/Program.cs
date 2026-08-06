/*
 * Demonstrator für Semaphore
 * 
 * C. Herren
 * 15.04.2025
 * V2
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Use_semaphor
{
    class Program
    {
        //Instantiieren eines Semaphors mit 2 Kanälen, 2 davon sind frei
        static private Semaphore sem = new Semaphore(2, 2);

        //Methode zum Starten von mehreren Threads
        static public void starte_Threads(int anzahl)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(Benutze_Semaphor);
                t.Name = "Thread" + i.ToString();
                t.Start();
            }
        }

        //eigentliche Threadmethode
        static public void Benutze_Semaphor()
        {
            sem.WaitOne();
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(100); 
                Console.WriteLine("Thread {0}: ", Thread.CurrentThread.Name);
            }
            sem.Release();
        }

        static void Main(string[] args)
        {
            //Starten
            starte_Threads(10);
            Console.Read();
        }
    }
}
