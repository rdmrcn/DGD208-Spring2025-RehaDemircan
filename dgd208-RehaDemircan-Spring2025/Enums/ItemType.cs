using System;
using System.Threading.Tasks;

namespace DG208_Spring2025_RehaDemircan
{
    public class Item
    {
        public string Name { get; }
        public ItemType Type { get; }
        public int HungerEffect { get; }
        public int FunEffect { get; }
        public int SleepEffect { get; }
        public int UseDurationMs { get; } // delay in ms when using item

        public Item(string name, ItemType type, int hungerEffect, int funEffect, int sleepEffect, int useDurationMs)
        {
            Name = name;
            Type = type;
            HungerEffect = hungerEffect;
            FunEffect = funEffect;
            SleepEffect = sleepEffect;
            UseDurationMs = useDurationMs;
        }

        public async Task UseAsync(Pet pet)
        {
            Console.WriteLine($"Using {Name} on {pet.Name}...");
            await Task.Delay(UseDurationMs);
            pet.ChangeStats(HungerEffect, FunEffect, SleepEffect);
            Console.WriteLine($"{pet.Name}'s stats updated!");
        }
    }
}
