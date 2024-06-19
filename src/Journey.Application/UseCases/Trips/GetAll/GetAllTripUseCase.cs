using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;

namespace Journey.Application.UseCases.Trips.GetAll;

public class GetAllTripUseCase
{
    public ResponseTripsJson Execute()
    {
        var dbContext = new JourneyDbContext();
        var trips = dbContext.Trips.ToList();
        
        return new ResponseTripsJson
        {
            Trips = trips.Select(trip => new ResponseShortTripJson
            {
                Id = trip.Id,
                EndDate = trip.EndDate,
                Name = trip.Name,
                StartDate = trip.StartDate,
            }).ToList()
        };
    }
}