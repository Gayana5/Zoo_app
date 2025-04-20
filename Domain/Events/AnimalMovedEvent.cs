namespace Domain.Events;

public class AnimalMovedEvent
{
    public int AnimalId { get; }
    public int ToEnclosureId { get; }

    public AnimalMovedEvent(int animalId, int toId)
    {
        AnimalId = animalId;
        ToEnclosureId = toId;
    }
}
