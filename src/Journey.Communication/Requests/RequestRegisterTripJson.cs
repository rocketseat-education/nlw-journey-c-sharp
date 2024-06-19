namespace Journey.Communication.Requests;
public class RequestRegisterTripJson
{
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
