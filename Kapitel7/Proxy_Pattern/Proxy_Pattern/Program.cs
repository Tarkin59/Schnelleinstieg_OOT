using System;

namespace Proxy_pattern
{
    //Verwendetes Interface (subject im Klassendiagramm)
    //regelt Zugriff auf mathematische Grundfunktionen
    public interface IMath
    {
        double Add(double x, double y);

        double Sub(double x, double y);

        double Mul(double x, double y);

        double Div(double x, double y);
    }

    //Das real subject im Sinne der Definition
    class Math : IMath
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }

        public double Mul(double x, double y)
        {
            return x * y;
        }

        public double Div(double x, double y)
        {
            return x / y;
        }

    }

    //Der Proxy --> im Sinne der Definition
    class MathProxy : IMath
    {
        //Instanz des real Subject
        private Math _math = new Math();


        public double Add(double x, double y)
        {
            return 0; //Addieren haben wir untersagt !
        }

        public double Sub(double x, double y)
        {
            return _math.Sub(x, y);
        }

        public double Mul(double x, double y)
        {
            return _math.Mul(x, y);
        }

        public double Div(double x, double y)
        {
            return _math.Div(x, y);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // Instanz des Proxys erzeugen
            MathProxy proxy = new MathProxy();

            // Berechnung ausführen
            Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));

            Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));

            Console.WriteLine("4 * 2 = " + proxy.Mul(4, 2));

            Console.WriteLine("4 / 2 = " + proxy.Div(4, 2));

            // Wait for user
            Console.ReadKey();

        }
    }
}
