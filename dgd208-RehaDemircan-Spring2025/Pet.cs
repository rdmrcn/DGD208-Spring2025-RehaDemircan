using dgd208_RehaDemircan_Spring2025.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DG208_Spring2025_RehaDemircan
{
    public class Pet
    {
        public string Name { get; }
        public PetType Type { get; }

        public int Hunger { get; private set; } = 50;
        public int Sleep { get; private set; } = 50;
        public int Fun { get; private set; } = 50;

        public bool IsAlive { get; private set; } = true;

        private CancellationTokenSource decayTokenSource;

        // Event fired on pet death
        public event Action<Pet> PetDied;

        public Pet(PetType type, string name)
        {
            Type = type;
            Name = name;
            decayTokenSource = new CancellationTokenSource();
            _ = StartDecayAsync(decayTokenSource.Token);
        }

        private async Task StartDecayAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested && IsAlive)
            {
                await Task.Delay(3000, token); // decrease every 3 seconds

                ChangeStats(-1, -1, -1); // stats decrease

                if (Hunger <= 0 || Sleep <= 0 || Fun <= 0)
                {
                    IsAlive = false;
                    Console.WriteLine($"\n💀 {Name} has died due to poor care!");
                    PetDied?.Invoke(this);
                }
            }
        }

        public void StopDecay()
        {
            decayTokenSource.Cancel();
        }

        public void ChangeStats(int hungerChange, int funChange, int sleepChange)
        {
            if (!IsAlive) return;

            Hunger = Math.Clamp(Hunger + hungerChange, 0, 100);
            Fun = Math.Clamp(Fun + funChange, 0, 100);
            Sleep = Math.Clamp(Sleep + sleepChange, 0, 100);
        }

        public void ShowStats()
        {
            Console.WriteLine($"[{Type}] {Name} - Hunger: {Hunger}, Fun: {Fun}, Sleep: {Sleep}");
        }
    }
}
