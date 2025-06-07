using System;
using System.Threading.Tasks;

namespace DG208_Spring2025_RehaDemircan
{
    public class Item
    {
        public string Name { get; }
        public ItemType Type { get; }
        public int HealthEffect { get; }
        public int FunEffect { get; }
        public int SleepEffect { get; }
        public int UseDurationMs { get; }

        public Item(string name, ItemType type, int healthEffect, int funEffect, int sleepEffect, int useDurationMs)
        {
            Name = name;
            Type = type;
            HealthEffect = healthEffect;
            FunEffect = funEffect;
            SleepEffect = sleepEffect;
            UseDurationMs = useDurationMs;
        }

        public async Task UseAsync(Pet pet)
        {
            Console.WriteLine($"Using {Name} on {pet.Name}...");
            await Task.Delay(UseDurationMs);
            pet.ChangeStats(HealthEffect, FunEffect, SleepEffect);
            Console.WriteLine($"{pet.Name}'s stats updated!");
        }
    }
}
