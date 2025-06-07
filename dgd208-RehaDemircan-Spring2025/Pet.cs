namespace DG208_Spring2025_RehaDemircan
{
    public class Pet
    {
        public string Name { get; }
        public PetType Type { get; }
        public string Breed { get; }

        public int Health { get; private set; } = 50;
        public int Sleep { get; private set; } = 50;
        public int Fun { get; private set; } = 50;

        public bool IsAlive { get; private set; } = true;

        private CancellationTokenSource decayTokenSource;

        public event Action<Pet> PetDied;

        public Pet(PetType type, string name, string breed)
        {
            Type = type;
            Name = name;
            Breed = breed;
            decayTokenSource = new CancellationTokenSource();
            _ = StartDecayAsync(decayTokenSource.Token);
        }

        private async Task StartDecayAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested && IsAlive)
            {
                await Task.Delay(3000, token);
                ChangeStats(-2, -1, -4); // Health, Fun, Sleep decay

                if (Health <= 0 || Sleep <= 0 || Fun <= 0)
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

        public void ChangeStats(int healthChange, int funChange, int sleepChange)
        {
            if (!IsAlive) return;

            Health = Math.Clamp(Health + healthChange, 0, 100);
            Fun = Math.Clamp(Fun + funChange, 0, 100);
            Sleep = Math.Clamp(Sleep + sleepChange, 0, 100);
        }

        public void ShowStats()
        {
            Console.WriteLine($"[{Type}] {Name} ({Breed}) - Health: {Health}, Fun: {Fun}, Sleep: {Sleep}");
        }
    }
}
