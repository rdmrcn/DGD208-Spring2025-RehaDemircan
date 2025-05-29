using dgd208_RehaDemircan_Spring2025.Enums;
using dgd208_RehaDemircan_Spring2025;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DG208_Spring2025_RehaDemircan
{
    public class Game
    {
        private List<Pet> pets = new List<Pet>();
        private List<Item> items = new List<Item>();

        public Game()
        {
            // Create some sample items
            items.Add(new Item("Dog Food", ItemType.Food, 20, 0, 0, 2000));
            items.Add(new Item("Catnip Toy", ItemType.Toy, 0, 15, 0, 1500));
            items.Add(new Item("Bird Bed", ItemType.Bed, 0, 0, 25, 3000));
        }

        public async Task RunAsync()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Interactive Pet Simulator ---");
                Console.WriteLine("1. Adopt a pet");
                Console.WriteLine("2. View pets");
                Console.WriteLine("3. Use item on pet");
                Console.WriteLine("4. Show creator info");
                Console.WriteLine("0. Exit");

                Console.Write("Select an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AdoptPet();
                        break;
                    case "2":
                        ShowPets();
                        break;
                    case "3":
                        await UseItemMenuAsync();
                        break;
                    case "4":
                        ShowCreatorInfo();
                        break;
                    case "0":
                        running = false;
                        StopAllPets();
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again.");
                        break;
                }
            }
        }

        private void AdoptPet()
        {
            Console.WriteLine("Choose pet type:");
            foreach (var val in Enum.GetValues(typeof(PetType)))
                Console.WriteLine($"{(int)val + 1}. {val}");

            Console.Write("Your choice: ");
            if (int.TryParse(Console.ReadLine(), out int petChoice) &&
                Enum.IsDefined(typeof(PetType), petChoice - 1))
            {
                PetType chosenType = (PetType)(petChoice - 1);
                Console.Write("Enter pet's name: ");
                string name = Console.ReadLine();

                var pet = new Pet(chosenType, name);
                pet.PetDied += OnPetDied;
                pets.Add(pet);

                Console.WriteLine($"You adopted {name} the {chosenType}!");
            }
            else
            {
                Console.WriteLine("Invalid pet type.");
            }
        }

        private void ShowPets()
        {
            if (pets.Count == 0)
            {
                Console.WriteLine("You have no pets.");
                return;
            }

            Console.WriteLine("Your pets:");
            foreach (var pet in pets)
            {
                pet.ShowStats();
            }
        }

        private async Task UseItemMenuAsync()
        {
            if (pets.Count == 0)
            {
                Console.WriteLine("No pets to use items on.");
                return;
            }

            Console.WriteLine("Select a pet:");
            for (int i = 0; i < pets.Count; i++)
                Console.WriteLine($"{i + 1}. {pets[i].Name} ({pets[i].Type})");

            if (!int.TryParse(Console.ReadLine(), out int petIndex) || petIndex < 1 || petIndex > pets.Count)
            {
                Console.WriteLine("Invalid pet choice.");
                return;
            }
            Pet chosenPet = pets[petIndex - 1];

            Console.WriteLine("Select an item:");
            for (int i = 0; i < items.Count; i++)
                Console.WriteLine($"{i + 1}. {items[i].Name} (Hunger +{items[i].HungerEffect}, Fun +{items[i].FunEffect}, Sleep +{items[i].SleepEffect})");

            if (!int.TryParse(Console.ReadLine(), out int itemIndex) || itemIndex < 1 || itemIndex > items.Count)
            {
                Console.WriteLine("Invalid item choice.");
                return;
            }
            Item chosenItem = items[itemIndex - 1];

            await chosenItem.UseAsync(chosenPet);
        }

        private void ShowCreatorInfo()
        {
            Console.WriteLine("Project by: Reha Demircan - Student Number: 2305041069");
        }

        private void OnPetDied(Pet pet)
        {
            pets.Remove(pet);
            Console.WriteLine($"Pet {pet.Name} has been removed from your list.");
        }

        private void StopAllPets()
        {
            foreach (var pet in pets)
            {
                pet.StopDecay();
            }
        }
    }
}
