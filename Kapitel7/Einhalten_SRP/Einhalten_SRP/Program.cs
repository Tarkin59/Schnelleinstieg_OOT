namespace Einhalten_SRP
{
    //Nun eine Verantwortung pro Klasse
    public class ReportProcessor
    {
        public List<string> Process(List<string> data)
        {
            return data.Select(d => d.ToUpper()).ToList();
        }
    }

    //Nun eine Verantwortung pro Klasse
    public class ReportSaver
    {
        public void Save(List<string> processedData, string fileName = "report.txt")
        {
            File.WriteAllLines(fileName, processedData);
        }
    }

    //Nun eine Verantwortung pro Klasse
    public class ReportPrinter
    {
        public void Print(List<string> processedData)
        {
            foreach (var line in processedData)
            {
                Console.WriteLine(line);
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var data = new List<string> { "alpha", "beta", "gamma" };

            var processor = new ReportProcessor();
            var saver = new ReportSaver();
            var printer = new ReportPrinter();

            var processed = processor.Process(data);
            saver.Save(processed);
            printer.Print(processed);

        }
    }
}
