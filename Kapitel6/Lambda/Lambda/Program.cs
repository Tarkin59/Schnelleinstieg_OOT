namespace Lambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Liste von Zahlen
            List<int> zahlen = new List<int> { 1, 2, 3, 4, 5 };

            // Lambda-Ausdruck zum Filtern: nur gerade Zahlen
            var geradeZahlen = zahlen.Where(x => x % 2 == 0);

            // Ausgabe
            foreach (var zahl in geradeZahlen)
            {
                Console.WriteLine(zahl);
            }

        }
    }
}
