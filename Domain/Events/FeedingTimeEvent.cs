namespace Domain.Events;

public class FeedingTimeEvent
{
    public int AnimalId { get; }
    public DateTime FeedingTime { get; }

    public FeedingTimeEvent(int animalId, DateTime feedingTime)
    {
        AnimalId = animalId;
        FeedingTime = feedingTime;
    }
}
