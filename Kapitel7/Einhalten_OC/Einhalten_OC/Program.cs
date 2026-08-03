namespace Einhalten_OC
{
    // 1. Das Interface definieren
    public interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }

    // 2. Die VIP-Strategie implementieren
    public class VipDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount) => amount * 0.20;
    }

    // (Optional) Eine weitere Strategie für normale Kunden zur Demonstration
    public class RegularDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount) => amount * 0.05;
    }

    // 3. Die fehlende Klasse "DiscountCalculator"
    public class DiscountCalculator
    {
        // Diese Methode nimmt die gewünschte Strategie und den Betrag entgegen
        public double CalculateDiscount(IDiscountStrategy strategy, double amount)
        {
            if (strategy == null)
            {
                throw new ArgumentNullException(nameof(strategy), "Es muss eine Rabatt-Strategie übergeben werden.");
            }

            return strategy.CalculateDiscount(amount);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Den Rechner instanziieren
            var calculator = new DiscountCalculator();

            double einkaufsBetrag = 1000;
            Console.WriteLine($"Einkaufsbetrag: {einkaufsBetrag}\n");

            // --- VIP-Kunde ---
            IDiscountStrategy vipStrategy = new VipDiscount();
            double vipDiscount = calculator.CalculateDiscount(vipStrategy, einkaufsBetrag);
            Console.WriteLine($"VIP Discount (20%): {vipDiscount}");

            // --- Regulärer Kunde ---
            IDiscountStrategy regularStrategy = new RegularDiscount();
            double regularDiscount = calculator.CalculateDiscount(regularStrategy, einkaufsBetrag);
            Console.WriteLine($"Regular Discount (5%): {regularDiscount}");

            // Warte auf Benutzereingabe, bevor die Konsole schließt
            Console.ReadLine();

            Console.Read();
        }
    }
}
