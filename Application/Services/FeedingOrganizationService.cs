namespace Application.Services;
using Domain.ValueObjects;
using Domain.Entities;
using Domain.Events;
using Interfaces;
using Infrastructure.Interfaces;

public class FeedingOrganizationService : IFeedingOrganizationService
{
    private readonly IFeedingScheduleRepository _feedingRepo;
    private readonly IAnimalRepository _animalRepo;

    public FeedingOrganizationService(
        IFeedingScheduleRepository feedingRepo,
        IAnimalRepository animalRepo)
    {
        _feedingRepo = feedingRepo;
        _animalRepo = animalRepo;
    }
    public FeedingSchedule AddFeeding(int animalId, DateTime feedingTime, Food food)
    {
        var animal = _animalRepo.GetById(animalId);
        if (animal == null)
            throw new ArgumentException($"Animal {animalId} not found");

        var schedule = new FeedingSchedule(animalId, feedingTime, food);
        _feedingRepo.Add(schedule);
        return schedule;
    }
    public void MarkFeedingCompleted(int feedingId)
    {
        var feeding = _feedingRepo.GetById(feedingId);
        if (feeding == null)
        {
            throw new ArgumentException($"Feeding {feedingId} not found");
        }
        _feedingRepo.MarkAsDone(feedingId);

        var ev = new FeedingTimeEvent(feeding.AnimalId, feeding.FeedingTime);
        DomainEventDispatcher.Dispatch(ev);
    }
    public IEnumerable<FeedingSchedule> GetFeedingSchedule() => _feedingRepo.GetAll();
}
