using System.IO;
using System.Security.Cryptography.X509Certificates;
using static System.Console;
//1
namespace AddressList
{
    internal class Program
    {
        //6
        static List<Person> AddressList = new List<Person>(20);
        //5
        class Person
        {
            public string name { get; private set; }
            public string phone { get; private set; }
            public string address { get; private set; }
            public Person(string newName, string newPhone, string newAddress) {
            this.name = newName;
            this.phone = newPhone;
            this.address = newAddress;
            }
            public static void Print (Person p)
            { WriteLine($"Namn: {p.name} \nTelefon: {p.phone}\nAdress: {p.address}\n"); }

        }
        static void Main(string[] args)
        {
            WriteLine("Hej och välkommen till telefonlistan.");
            WriteLine("Skriv 'help' för hjälp!");
            string command;
            do
            {
                Write("Kommando: ");
                command = ReadLine();
                if (command == "help")
                {
                    WriteLine($"Tyvärr ej implementerat!");
                }
                //2
                else if (command == "load")
                {
                    //3
                    using (StreamReader sr = new StreamReader("adresser.txt"))
                    {
                        string line;
                        //4
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            WriteLine($"Namn: {parts[0]}\nTelefon: {parts[1]}\nAdress: {parts[2]}\n");
                            //5
                            Person p = new Person(parts[0], parts[1], parts[2]);
                            //7
                            AddressList.Add(p);
                        }
                    }

                }
                //8
                else if (command == "list")
                {
                    foreach (Person p in AddressList)
                        Person.Print(p);
                }
                //9
                else if (command == "add")
                {
                    Write("Namn: ");
                    string n=ReadLine();
                    Write("Telefonnummer: ");
                    string p=ReadLine();
                    Write("Adress: ");
                    string a=ReadLine();
                    AddressList.Add(new Person(n, p, a));
                    WriteLine("Glöm inte att spara dina ändringar med \"save\".");
                }
                //10
                else if (command == "save")
                {
                    Write("Namnge filen att spara i, avsluta med \".txt\" : ");
                    using (StreamWriter sw = new StreamWriter(ReadLine(), false))
                    {
                        foreach(Person p in AddressList)
                        {                            
                            string[] person = {p.name, p.phone, p.address};
                            sw.WriteLine(String.Join(", ", person));
                        }
                    }
                }
                //11
                else if (command == "delete")
                {
                    Write("Vem ska raderas: ");
                    string n = ReadLine();                    
                    int i=AddressList.FindIndex(x => x.name.Contains(n));
                    AddressList.RemoveAt(i);
                    WriteLine("Glöm inte att spara dina ändringar med \"save\".");
                }
                else if (command == "quit")
                {

                }
                else
                {
                    WriteLine($"Okänt kommando: {command}");
                }
            } while (command != "quit");
            WriteLine("Hej då!");
        }
    }
}