namespace Verletzen_OC
{

    public class DiscountCalculator
    {
        public double CalculateDiscount(string customerType, double amount)
        {
            // Standardkunde
            if (customerType == "Standard")
            {
                return amount * 0.05;
            }
            // Premiumkunde
            else if (customerType == "Premium")
            {
                return amount * 0.10;
            }
            // Neu auch ein VIP-Kunde--Hier verletzen wir das Open-Closed-Prinzip,
            // da wir die Klasse DiscountCalculator ändern müssen, um einen neuen Kundentyp hinzuzufügen.
            else if (customerType == "VIP")
            {
                return amount * 0.20;
            }
            else
            {
                return 0;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Den Rechner instanziieren
            DiscountCalculator calculator = new DiscountCalculator();

            // Ein fester Einkaufsbetrag zum Testen
            double einkaufsBetrag = 200.00;

            Console.WriteLine($"--- Rabattberechnung (Einkaufswert: {einkaufsBetrag} EUR) ---\n");

            // 2. Standard-Kunde erstellen und Rabatt berechnen
            string standardKunde = "Standard";
            double standardRabatt = calculator.CalculateDiscount(standardKunde, einkaufsBetrag);
            double standardEndpreis = einkaufsBetrag - standardRabatt;

            Console.WriteLine($"Kundentyp: {standardKunde}");
            Console.WriteLine($"Rabatt: {standardRabatt} EUR (5%)");
            Console.WriteLine($"Zu zahlen: {standardEndpreis} EUR\n");

            // 3. VIP-Kunde erstellen und Rabatt berechnen
            string vipKunde = "VIP";
            double vipRabatt = calculator.CalculateDiscount(vipKunde, einkaufsBetrag);
            double vipEndpreis = einkaufsBetrag - vipRabatt;

            Console.WriteLine($"Kundentyp: {vipKunde}");
            Console.WriteLine($"Rabatt: {vipRabatt} EUR (20%)");
            Console.WriteLine($"Zu zahlen: {vipEndpreis} EUR");

            Console.Read();
        }
    }
    
}
