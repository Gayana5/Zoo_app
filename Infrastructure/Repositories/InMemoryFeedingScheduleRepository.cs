namespace Infrastructure.Repositories;

using Domain.Entities;
using Interfaces;

public class InMemoryFeedingScheduleRepository : IFeedingScheduleRepository
{
    private readonly Dictionary<int, FeedingSchedule> _schedules = new();
    private int _idCounter = 1;

    public void Add(FeedingSchedule schedule)
    {
        _schedules[_idCounter] = schedule;
        schedule.Id = _idCounter;
        _idCounter++;
    }

    public FeedingSchedule? GetById(int id)
    {
        _schedules.TryGetValue(id, out var schedule);
        return schedule;
    }

    public IEnumerable<FeedingSchedule> GetAll()
    {
        return _schedules.Values.OrderBy(s => s.FeedingTime).ToList();
    }

    public void Remove(int id)
    {
        if (!_schedules.Remove(id))
        {
            throw new ArgumentException($"Feeding {id} not found");
        }
    }

    public void Update(int id, FeedingSchedule schedule)
    {
        if (!_schedules.ContainsKey(id))
        {
            throw new ArgumentException($"Feeding {id} not found");
        }
        schedule.Id = id;
        _schedules[id] = schedule;
    }

    public void MarkAsDone(int id)
    {
        _schedules[id].MarkAsCompleted();
    }
}
