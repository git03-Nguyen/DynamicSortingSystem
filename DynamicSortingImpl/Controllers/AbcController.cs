using DynamicSortingImpl.Features.Abc;
using DynamicSortingImpl.Features.Abc.RequestResponse;
using DynamicSortingImpl.Features.Other;
using DynamicSortingImpl.Features.Other.RequestResponse;
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
    public async Task<IActionResult> Sort([FromBody] GetAbcRequest request)
    {
        var response = await _mediator.Send(new GetAbcQuery(request));
        return Ok(response);
    }
    
}