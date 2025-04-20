using System.Net.Mime;
using Domain.ValueObjects;

namespace Infrastructure.Repositories;

using Domain.Entities;
using Interfaces;

public class InMemoryAnimalRepository : IAnimalRepository
{
    private readonly Dictionary<int, Animal> _animals = new();
    private int _idCounter = 1;

    public void Add(Animal animal)
    {
        _animals.Add(_idCounter, animal);
        animal.Id = _idCounter;
        _idCounter += 1;
    }

    public Animal? GetById(int id)
    {
        if (!_animals.TryGetValue(id, out var animal))
        {
            throw new ArgumentException("Animal not found");
        }
        return _animals.GetValueOrDefault(id);
    }

    public IEnumerable<Animal> GetAll()
    {
        return _animals.Values.ToList();
    }

    public void Remove(int id)
    {
        if (!_animals.TryGetValue(id, out var animal))
        {
            throw new ArgumentException("Animal not found");
        }
        _animals.Remove(id);
    }
    
    public void Treat(int id)
    {
        if (!_animals.TryGetValue(id, out var animal))
        {
            throw new ArgumentException("Animal not found");
        }
        _animals[id].Treat();
    }

    public void Feed(int id)
    {
        if (!_animals.TryGetValue(id, out var animal))
        {
            throw new ArgumentException("Animal not found");
        }
        _animals[id].Feed();
    }

    public void MoveToEnclosure(int animalId, int enclosureId)
    {
        if (!_animals.TryGetValue(animalId, out var animal))
        {
            throw new ArgumentException("Animal not found");
        }
        _animals[animalId].MoveToEnclosure(enclosureId);
    }
}