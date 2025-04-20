namespace Infrastructure.Repositories;

using Domain.Entities;
using Interfaces;


public class InMemoryEnclosureRepository : IEnclosureRepository
{
    private readonly Dictionary<int, Enclosure> _enclosures = new();
    private int _idCounter = 1;

    public void Add(Enclosure enclosure)
    {
        _enclosures[_idCounter] = enclosure;
        enclosure.Id = _idCounter;
        _idCounter++;
    }

    public Enclosure? GetById(int id)
    {
        return _enclosures.GetValueOrDefault(id);
    }

    public IEnumerable<Enclosure> GetAll()
    {
        return _enclosures.Values.ToList();
    }

    public void Remove(int id)
    {
        if (!_enclosures.Remove(id, out var enclosure))
        {
            throw new ArgumentException("Enclosure not found");
        }
    }

    public void Update(Enclosure enclosure)
    {
        _enclosures[enclosure.Id] = enclosure;
    }

    public void Clean(int id)
    {
        if (!_enclosures.TryGetValue(id, out var enclosure))
        {
            throw new ArgumentException("Enclosure not found");
        }
        _enclosures[id].Clean();
    }
}

