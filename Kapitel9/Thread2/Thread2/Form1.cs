using System;
using System.Windows.Forms;
using System.Threading;

namespace Thread2
{
    public partial class Form1 : Form
    {
        // Gemeinsame Variable, auf die beide Threads zugreifen
        int summe = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // Methode, die von beiden Threads ausgeführt wird
        public void BerechneMitAnzeige(object anzahl)
        {
            // Kritischer Abschnitt: beide Threads greifen auf "summe" zu
            lock (this)
            {
                for (int i = 0; i < (int)anzahl; i++)
                {
                    Thread.Sleep(1000);   // simuliert Arbeit (1 Sekunde warten)

                    summe++;              // gemeinsamer Zähler
                    string s = "Thread " + Thread.CurrentThread.Name +
                               " : Summe = " + summe.ToString();

                    // ❌ Direkter Zugriff auf die UI aus dem Thread → nicht erlaubt
                    // listBox1.Items.Add(s);

                    // ✔️ Threadsicherer Zugriff auf die UI
                    listBox1.Invoke(new Action(() => listBox1.Items.Add(s)));
                }
            }
        }

        // Wird ausgeführt, wenn der Button geklickt wird
        private void button1_Click(object sender, EventArgs e)
        {
            // Thread 1 erzeugen
            Thread t1 = new Thread(BerechneMitAnzeige);
            t1.Name = "A";
            t1.Start(5);   // Parameter für die Schleife

            // Thread 2 erzeugen
            Thread t2 = new Thread(BerechneMitAnzeige);
            t2.Name = "B";
            t2.Start(5);   // gleicher Parameter
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Wird beim Laden des Formulars ausgeführt (hier leer)
        }
    }
}
