namespace Domain.Entities;
using ValueObjects;

public class FeedingSchedule
{
    public int Id { get; set; }
    public int AnimalId { get; private set; }
    public DateTime FeedingTime { get; private set; }
    public Food FoodType { get; private set; }
    public bool IsCompleted { get; private set; }

    public FeedingSchedule( int animalId, DateTime feedingTime, Food foodType)
    {
        AnimalId = animalId;
        FeedingTime = feedingTime;
        FoodType = foodType;
        IsCompleted = false;
    }

    public void MarkAsCompleted() => IsCompleted = true;
}
