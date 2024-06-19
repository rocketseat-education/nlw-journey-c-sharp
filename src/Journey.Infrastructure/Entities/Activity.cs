using Journey.Infrastructure.Enums;

namespace Journey.Infrastructure.Entities;
public class Activity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public ActivityStatus Status { get; set; }
    public Guid TripId { get; set; }
}
