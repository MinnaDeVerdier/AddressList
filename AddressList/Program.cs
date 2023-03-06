﻿using static System.Console;
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
            private string name, phone, address;
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
                        }
                    }
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