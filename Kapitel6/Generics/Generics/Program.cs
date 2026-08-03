namespace Generics
{
    internal class Program
    {
        // Generische Methode (static hinzugefügt für Aufruf aus Main)
        public static T GetFirst<T>(List<T> items)
        {
            if (items == null || items.Count == 0)
            {
                throw new ArgumentException("Die Liste darf nicht leer oder null sein.");
            }

            return items[0];
        }
        static void Main(string[] args)
        {

            // 1. Beispiel: Generische Liste mit Integer-Werten (Dein Code)
            List<int> zahlen = new List<int>();
            zahlen.Add(10);
            zahlen.Add(20);

            // Aufruf der generischen Methode
            int ersteZahl = GetFirst(zahlen);
            Console.WriteLine("Die erste Zahl ist: " + ersteZahl);

            // 2. Beispiel: Die gleiche Methode mit Strings wiederverwenden
            List<string> woerter = new List<string>();
            woerter.Add("Hallo");
            woerter.Add("Welt");

            // Aufruf derselben generischen Methode, diesmal mit Strings
            string erstesWort = GetFirst(woerter);
            Console.WriteLine("Das erste Wort ist: " + erstesWort);

            // Konsole offen halten
            Console.ReadLine();
        }
    }
}
