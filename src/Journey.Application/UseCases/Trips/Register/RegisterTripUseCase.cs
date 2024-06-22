using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;

namespace Journey.Application.UseCases.Trips.Register;

public class RegisterTripUseCase
{
    public ResponseShortTripJson Execute(RequestRegisterTripJson request)
    {
        Validate(request);

        var dbContext = new JourneyDbContext();

        var entity = new Trip
        {
            Name = request.Name,
            StartDate = request.StartDate,
            EndDate = request.EndDate
        };
        
        dbContext.Trips.Add(entity);
        dbContext.SaveChanges();

        return new ResponseShortTripJson
        {
            Id = entity.Id,
            Name = entity.Name,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
        };
    }

    private void Validate(RequestRegisterTripJson request)
    {
        var validator = new RegisterTripValidator();
        var result = validator.Validate(request);
        
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}