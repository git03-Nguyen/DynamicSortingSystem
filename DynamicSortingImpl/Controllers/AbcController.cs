using DynamicSortingImpl.FeatureQueries;
using DynamicSortingImpl.FeatureQueries.RequestResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DynamicSortingImpl.Controllers;

[ApiController]
[Route("[controller]")]
public class AbcController : ControllerBase
{
    private readonly IMediator _mediator;

    public AbcController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Test()
    {
        return Ok("Hello World");
    }
    
    [HttpPost]
    public async Task<IActionResult> Sort([FromBody] GetTestRequest request)
    {
        var response = await _mediator.Send(new GetTestQuery(request));
        return Ok(response);
    }
    
}