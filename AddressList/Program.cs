using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static System.Console;
namespace AddressList
{
    internal class Program
    {
        static List<Person> AddressList = new List<Person>(20);
        class Person
        {
            public string name { get; private set; }
            public string phone { get; private set; }
            public string address { get; private set; }
            public Person(string newName, string newPhone, string newAddress)
            {
                this.name = newName;
                this.phone = newPhone;
                this.address = newAddress;
            }
            public static void Print(Person p)
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
                    Help();
                }
                else if (command == "load")
                {
                    Write("Tryck enter för att ladda upp default-fil, annars skriv filens sökväg: ");
                    Load(ReadLine());
                }
                else if (command == "list")
                {
                    foreach (Person p in AddressList)
                        Person.Print(p);
                }
                else if (command == "add")
                {
                    Write("Namn: ");
                    string n = ReadLine();
                    Write("Telefonnummer: ");
                    string p = ReadLine();
                    Write("Adress: ");
                    string a = ReadLine();
                    AddressList.Add(new Person(n, p, a));
                    WriteLine("Glöm inte att spara dina ändringar med \"save\".");
                }
                //10
                else if (command == "save")
                {
                    Write("Namnge filen att spara i, avsluta med \".txt\" : ");
                    using (StreamWriter sw = new StreamWriter(ReadLine(), false))
                    {
                        foreach (Person p in AddressList)
                        {
                            string[] person = { p.name, p.phone, p.address };
                            sw.WriteLine(String.Join(", ", person));
                        }
                    }
                }
                //11
                else if (command == "delete")
                {
                    Write("Vem ska raderas: ");
                    string n = ReadLine();
                    int i = AddressList.FindIndex(x => x.name.Contains(n));
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
        public static void Help()
        {
            WriteLine("load - lagrar adresser från valfri lokal fil, eller från defaultfil" +
            "add - lagrar nya adresser i programmet" +
            "list - skriver ut de lagrade adresserna i programmet" +
            "delete - tar bort valfri adress ut programmet" +
            "save - sparar lagrade adresser till default eller valfri fil" +
            "quit - avslutar utan att spara lagrade adresser");
        }
        public static void Load(string path = null)
        {
            string filepath;
            if (path == null)
                filepath = $"{Environment.GetEnvironmentVariable("USERPROFILE")}\\Documents\\adresser.txt";
            else
                filepath = path;
            WriteLine("Laddar upp filen\n...");
            using (StreamReader sr = new StreamReader(filepath))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] parts = line.Split(',');
                    WriteLine($"Namn: {parts[0]}\nTelefon: {parts[1]}\nAdress: {parts[2]}\n");
                    Person p = new Person(parts[0], parts[1], parts[2]);
                    AddressList.Add(p);
                }
            }
        }
    }
}        
             
    
