namespace Application.Interfaces;

public interface IAnimalTransferService
{
    void TransferAnimal(int animalId, int newEnclosureId);
}