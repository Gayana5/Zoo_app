using Domain.Entities;

namespace Application.Services;
using Interfaces;
using Infrastructure.Interfaces;

public class ZooStatisticsService : IZooStatisticsService
{
    private readonly IAnimalRepository _animalRepo;
    private readonly IEnclosureRepository _enclosureRepo;

    public ZooStatisticsService(IAnimalRepository animalRepo, IEnclosureRepository enclosureRepo)
    {
        _animalRepo = animalRepo;
        _enclosureRepo = enclosureRepo;
    }

    public ZooStatistics GetStatistics()
    {
        var enclosures = _enclosureRepo.GetAll();
        var animals = _animalRepo.GetAll();

        var enumerable = enclosures as Enclosure[] ?? enclosures.ToArray();
        return new ZooStatistics
        {
            TotalAnimals = animals.Count(),
            TotalEnclosures = enumerable.Count(),
            FreeEnclosures = enumerable.Count(e => !e.AnimalIds.Any())
        };
    }
}
