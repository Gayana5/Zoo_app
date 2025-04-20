namespace Domain.Entities;

using Events;
using ValueObjects;

public class Animal
{
    public int Id { get; set; }
    public Species Species { get; private set; }
    public string Name { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public Gender Gender { get; private set; }
    public Food Food { get; private set; }
    public bool IsHealthy { get; private set; }

    public int EnclosureId { get; private set; }

    public Animal(Species species, string name, DateTime dob, Gender gender, Food favoriteFood)
    {
        Species = species;
        Name = name;
        DateOfBirth = dob;
        Gender = gender;
        Food = favoriteFood;
        IsHealthy = true;
    }

    public void MoveToEnclosure(int newEnclosureId)
    {
        EnclosureId = newEnclosureId;
    }
    public void Feed() { }

    public void Treat()
    {
        IsHealthy = true;
    } 
}
