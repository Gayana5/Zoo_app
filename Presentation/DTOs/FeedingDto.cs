namespace Presentation.DTOs;

using Domain.ValueObjects;

public class FeedingDto
{
    public int AnimalId { get; set; }
    public DateTime FeedingTime { get; set; }
    public Food Food { get; set; } = new Food("");
}