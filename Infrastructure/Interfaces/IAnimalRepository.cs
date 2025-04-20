namespace Infrastructure.Interfaces;

using Domain.Entities;

public interface IAnimalRepository
{
    Animal? GetById(int id);
    IEnumerable<Animal> GetAll();
    void Add(Animal animal);
    void Remove(int id);
    void Treat(int id);
    void Feed(int id);
    void MoveToEnclosure(int animalId, int enclosureId);
}
