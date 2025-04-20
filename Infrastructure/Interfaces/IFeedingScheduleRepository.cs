namespace Infrastructure.Interfaces;
using Domain.Entities;

public interface IFeedingScheduleRepository
{
    public void Add(FeedingSchedule schedule);
    public FeedingSchedule? GetById(int id);
    public IEnumerable<FeedingSchedule> GetAll();
    public void Remove(int id);
    public void Update(int id, FeedingSchedule schedule);
    public void MarkAsDone(int id);
}