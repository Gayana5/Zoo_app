namespace Infrastructure.Interfaces;
using Domain.Entities;

public interface IEnclosureRepository
{
    Enclosure? GetById(int id);
    IEnumerable<Enclosure> GetAll();
    void Add(Enclosure enclosure);
    void Update(Enclosure enclosure);
    void Remove(int id);
    void Clean(int id);
}
