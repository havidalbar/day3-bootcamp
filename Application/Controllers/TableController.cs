using Core.Features.Queries.PostTableSpecifications;
using Core.Features.Queries.GetTableSpecifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Core.Features.Queries.PutTableSpecifications;
using Core.Features.Queries.PostListSpecifications;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers;

public class TableController : BaseController
{
    private readonly IMediator _mediator;

    public TableController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("v1/table/specification/{id}")]
    [Authorize(Roles = "USER,ADMIN")]
    public async Task<GetTableSpecificationsResponse> GetTableSpecifications(Guid id)
    {
        var request = new GetTableSpecificationsQuery()
        {
            TableId = id
        };
        var response = await _mediator.Send(request);
        return response;
    }

    [HttpPost("v1/table/specification/")]
    [Authorize(Roles = "USER,ADMIN")]
    public async Task<PostTableSpecificationsResponse> PostTableSpecifications(PostTableSpecificationsQuery request)
    {
        var response = await _mediator.Send(request);
        return response;
    }

    [HttpGet("v1/table/specification/")]
    [Authorize(Roles = "USER,ADMIN")]
    public async Task<IActionResult> ListTableSpecifications(GetListTableSpecificationsQuery request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("v1/table/specification/")]
    [Authorize(Roles = "USER,ADMIN")]
    public async Task<IActionResult> PutTableSpecifications(PutTableSpecificationsQuery request)
    {
        var response = await _mediator.Send(request);
        if (response is null)
        {
            return NotFound("data meja tidak ada");
        }
        return Ok(response);
    }

    [HttpDelete("v1/table/specification/{id}")]
    [Authorize(Roles = "USER,ADMIN")]
    public async Task<IActionResult> DeleteTableSpecifications(DeleteTableSpecificationsQuery request)
    {
        var response = await _mediator.Send(request);
        if (response is null)
        {
            return NotFound("data meja tidak ada");
        }
        return Ok(response.Status);
    }

    [HttpPost("v1/table/specification/all")]
    [Authorize(Roles = "USER,ADMIN")]
    public async Task<IActionResult> PostTableSpecifications(PostListTableSpecificationsQuery request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}