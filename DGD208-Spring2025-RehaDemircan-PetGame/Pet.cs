using System;

public class Pet
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Hunger { get; set; }
    public int Sleep { get; set; }
    public int Fun { get; set; }

    public Pet(string name, string type)
    {
        Name = name;
        Type = type;
        Hunger = 50;
        Sleep = 50;
        Fun = 50;
    }

    public void DisplayStats()
    {
        Console.WriteLine($"Name: {Name}, Type: {Type}, Hunger: {Hunger}, Sleep: {Sleep}, Fun: {Fun}");
    }
}
