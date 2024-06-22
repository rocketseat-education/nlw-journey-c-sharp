using Journey.Communication.Enums;

namespace Journey.Communication.Responses;
public class ResponseActivityJson
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public ActivityStatus Status { get; set; }
}
