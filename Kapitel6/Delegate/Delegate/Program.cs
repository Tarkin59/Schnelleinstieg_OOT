namespace Delegate
{
    internal class Program
    {
        //Deklaration eines Delegates
        delegate int RechenOperation(int a, int b);

        //Methode, passend zum Delegate
        static int Addieren(int a, int b)
        {
            return a + b;

        }

        static void Main(string[] args)
        {
            //Zuweisung der Methode an den Delegate
            RechenOperation op = Addieren;

            //Aufruf der Methode über den Delegate
            int ergebnis = op(5, 3);
            
            Console.WriteLine(ergebnis);

            Console.ReadLine();
        }
    }
}
