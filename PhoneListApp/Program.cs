namespace PhoneListApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hej och välkommen till telefonlistan.");
            Console.WriteLine("Skriv 'hjälp' för hjälp!");
            string command;
            do
            {
                Console.Write("Kommando: ");
                command = Console.ReadLine();
                if (command == "hjälp")
                {
                    Console.WriteLine($"Tyvärr ej implementerat!");
                }
                else if(command == "sluta")
                {

                }
                else
                {
                    Console.WriteLine($"Okänt kommando: {command}");
                }
            } while (command != "sluta");
            Console.WriteLine("Hej då!");
        }
    }
}