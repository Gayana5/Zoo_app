namespace Application.Interfaces;
using Domain.ValueObjects;
using Domain.Entities;

public interface IFeedingOrganizationService
{
    FeedingSchedule AddFeeding(int animalId, DateTime feedingTime, Food food);
    void MarkFeedingCompleted(int feedingId);
    IEnumerable<FeedingSchedule> GetFeedingSchedule();
  
}
