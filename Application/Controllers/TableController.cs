using Core.Features.Queries.PostTableSpecifications;
using Core.Features.Queries.GetTableSpecifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

public class TableController : BaseController
{
    private readonly IMediator _mediator;

    public TableController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("v1/table/specification/{id}")]
    public async Task<GetTableSpecificationsResponse> GetTableSpecifications(Guid id)
    {
        var request = new GetTableSpecificationsQuery()
        {
            TableSpecificationId = id
        };
        var response = await _mediator.Send(request);
        return response;
    }

    [HttpPost("v1/table/specification/")]
    public async Task<PostTableSpecificationsResponse> PostTableSpecifications(PostTableSpecificationsQuery request)
    {
        var response = await _mediator.Send(request);
        return response;
    }

    [HttpGet("v1/table/specification/")]
    public async Task<IActionResult> ListTableSpecifications(GetListTableSpecificationsQuery request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}