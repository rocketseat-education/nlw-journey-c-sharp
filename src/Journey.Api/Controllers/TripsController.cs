using Journey.Application.UseCases.Trips.GetAll;
using Journey.Application.UseCases.Trips.Register;
using Journey.Communication.Requests;
using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    // POST
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterTripJson request)
     {
        try
        {
            var useCase = new RegisterTripUseCase();
            var response =  useCase.Execute(request);
            return Created(string.Empty, response);
        }
        catch (JourneyException ex)
        {
            return BadRequest(ex.Message);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
        }
    }
    
    //Get
    [HttpGet]
    public IActionResult GetAll()
    {
        var userCase = new GetAllTripUseCase();
        var response = userCase.Execute();
        return Ok(response);
    }
}