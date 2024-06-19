namespace Journey.Communication.Responses;
public class ResponseTripJson
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public IList<ResponseActivityJson> Activities { get; set; } = [];
}
