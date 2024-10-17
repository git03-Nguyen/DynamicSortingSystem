using DynamicSortingImpl.FeatureQueries;
using DynamicSortingImpl.FeatureQueries.Other;
using DynamicSortingImpl.FeatureQueries.Other.RequestResponse;
using DynamicSortingImpl.FeatureQueries.Test;
using DynamicSortingImpl.FeatureQueries.Test.RequestResponse;
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

    [HttpPost]
    [Route("other")]
    public async Task<IActionResult> Other([FromBody] GetOtherRequest request)
    {
        var response = await _mediator.Send(new GetOtherQuery(request));
        return Ok(response);
    }
    
    [HttpPost]
    [Route("sort")]
    public async Task<IActionResult> Sort([FromBody] GetTestRequest request)
    {
        var response = await _mediator.Send(new GetTestQuery(request));
        return Ok(response);
    }
    
}