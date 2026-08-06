
using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        // Erzeugen eines neuen Threads, der die Methode "Berechne" ausführt.
        // Der Parameter 50 wird als Argument an die Methode übergeben.
        Thread t1 = new Thread(Berechne);
        t1.Name = "eins";          // Vergibt einen Namen für Debug-Ausgaben
        t1.Start(50);              // Startet den Thread mit Parameter 50

        // Zweiter Thread mit anderem Parameter
        Thread t2 = new Thread(Berechne);
        t2.Name = "zwei";
        t2.Start(20);

        // Verhindert, dass das Programm sofort endet
        Console.ReadLine();
    }

    // Methode, die von beiden Threads ausgeführt wird.
    // "object anzahl" ist notwendig, weil Thread.Start() nur object übergeben kann.
    private static void Berechne(object anzahl)
    {
        // Schleife läuft bis zur übergebenen Anzahl
        for (int i = 0; i < (int)anzahl; i++)
        {
            // Debug-Ausgabe zeigt den Threadnamen und den aktuellen Schleifenwert
            Console.WriteLine("Thread " + Thread.CurrentThread.Name + " arbeitet " + i);
        }

        // Abschlussmeldung des Threads
        Debug.Print("Thread " + Thread.CurrentThread.Name + " ist am Ende");
    }
}
