using System;
using System.Collections.Generic;

class Program
{
    static List<Pet> pets = new List<Pet>();

    static void Main()
    {
        Console.WriteLine("=== Virtual Pet Game ===");
        Console.WriteLine("Created by: [Your Name] - [Your Student Number]");

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Adopt a new pet");
            Console.WriteLine("2. View adopted pets");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AdoptPet();
                    break;
                case "2":
                    ViewPets();
                    break;
                case "3":
                    running = false;
                    Console.WriteLine("bye bye");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void AdoptPet()
    {
        Console.Write("Enter pet name: ");
        string name = Console.ReadLine();

        Console.Write("Enter pet type (e.g. Dog, Cat, Bird ):");
        string type = Console.ReadLine();

        Pet newPet = new Pet(name, type);
        pets.Add(newPet);
        Console.WriteLine($"{name} the {type} has been adopted");
    }

    static void ViewPets()
    {
        if (pets.Count == 0)
        {
            Console.WriteLine("You have no pets.");
            return;
        }

        Console.WriteLine("\nYour Pets:");
        foreach (var pet in pets)
        {
            pet.DisplayStats();
        }
    }
}
