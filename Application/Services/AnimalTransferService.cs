using System.Runtime.InteropServices.JavaScript;

namespace Application.Services;
using Interfaces;
using Infrastructure.Interfaces;
using Domain.Events;

public class AnimalTransferService : IAnimalTransferService
{
    private readonly IAnimalRepository _animalRepo;
    private readonly IEnclosureRepository _enclosureRepo;

    public AnimalTransferService(IAnimalRepository animalRepo, IEnclosureRepository enclosureRepo)
    {
        _animalRepo = animalRepo;
        _enclosureRepo = enclosureRepo;
    }

    public void TransferAnimal(int animalId, int targetEnclosureId)
    {
        var animal = _animalRepo.GetById(animalId);
        if (animal == null)
        {
            throw new InvalidOperationException("Animal not found.");
        }
        var targetEnclosure = _enclosureRepo.GetById(targetEnclosureId);
        if (targetEnclosure == null)
        {
            throw new InvalidOperationException("Target enclosure not found.");
        }
        if (!targetEnclosure.CanAddAnimal())
        {
            throw new InvalidOperationException("Target enclosure is full.");
        }
        
        var currentEnclosureId = animal.EnclosureId;
        if (currentEnclosureId != 0)
        {
            var currentEnclosure = _enclosureRepo.GetById(animal.EnclosureId);
            if (currentEnclosure == null)
            {
                throw new InvalidOperationException("Enclosure not found.");
            }
            currentEnclosure.RemoveAnimal(animal.Id);
            _enclosureRepo.Update(currentEnclosure);
        }
        
        targetEnclosure.AddAnimal(animal.Id);
        animal.MoveToEnclosure(targetEnclosureId);
        _enclosureRepo.Update(targetEnclosure);
        
        var ev = new AnimalMovedEvent(animal.Id, targetEnclosure.Id);
        DomainEventDispatcher.Dispatch(ev);
    }
}
