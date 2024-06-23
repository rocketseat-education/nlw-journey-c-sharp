using Journey.Application.UseCases.Trips.Activities.Complete;
using Journey.Application.UseCases.Trips.Activities.Delete;
using Journey.Application.UseCases.Trips.Activities.Register;
using Journey.Application.UseCases.Trips.Delete;
using Journey.Application.UseCases.Trips.GetAll;
using Journey.Application.UseCases.Trips.GetById;
using Journey.Application.UseCases.Trips.Register;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    // POST
    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestRegisterTripJson request)
     {
         var useCase = new RegisterTripUseCase();
         var response =  useCase.Execute(request);
         return Created( string.Empty, response);
     }
    
    //GET
    [HttpGet]
    [ProducesResponseType(typeof(ResponseTripsJson), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllTripUseCase();
        var response = useCase.Execute();
        return Ok(response);
    }
    
    //GET ID
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTripsJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var useCase = new GetTripByIdUseCase();
        var response = useCase.Execute(id);
        return Ok(response);
    }
    
    //DELETE ID
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var useCase = new DeleteTripByIdUseCase();
        useCase.Execute(id);
        return NoContent();
    }
    
    //POST Activity
    [HttpPost]
    [Route("{tripId}/activity")]
    [ProducesResponseType(typeof(ResponseActivityJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult RegisterActivity([FromRoute] Guid tripId, [FromBody] RequestRegisterActivityJson request)
    {
        var useCase = new RegisterActivityForTripUseCase();
        var response = useCase.Execute(tripId, request);
        return Created(string.Empty, response);
    }
    
    //PUT Activity
    [HttpPut]
    [Route("{tripId}/activity/{activityId}/complete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult CompleteActivity([FromRoute] Guid tripId, [FromRoute] Guid activityId)
    {
        var useCase = new CompleteActivityForTripUseCase();
        useCase.Execute(tripId, activityId);
        return NoContent();
    }
    
    //DELETE Activity
    [HttpPut]
    [Route("{tripId}/activity/{activityId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult DeleteActivity([FromRoute] Guid tripId, [FromRoute] Guid activityId)
    {
        var useCase = new DeleteActivityForTripUseCase();
        useCase.Execute(tripId, activityId);
        return NoContent();
    }
}