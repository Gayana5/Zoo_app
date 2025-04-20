namespace Domain.Entities;
using ValueObjects;

public class Enclosure(EnclosureType type, int size, int maxCapacity)
{
    public int Id { get; set; }
    public EnclosureType Type { get; private set; } = type;
    public int Size { get; private set; } = size;
    private int MaxCapacity { get;   } = maxCapacity;
    public List<int> AnimalIds { get; } = new();


    public bool CanAddAnimal() => AnimalIds.Count < MaxCapacity;

    public void AddAnimal(int animalId)
    {
        if (!CanAddAnimal()) throw new InvalidOperationException("Enclosure is full.");
        AnimalIds.Add(animalId);
    }

    public void RemoveAnimal(int animalId) => AnimalIds.Remove(animalId);

    public void Clean() { }
}
