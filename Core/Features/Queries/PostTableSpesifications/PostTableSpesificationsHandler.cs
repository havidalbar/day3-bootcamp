using System;
using Core.Features.Queries.GetTableSpecifications;
using MediatR;
using Persistence.Models;
using Persistence.Repositories;

namespace Core.Features.Queries.PostTableSpesifications
{
	public class PostTableSpesificationsHandler : IRequestHandler<PostTableSpesificationsQuery, PostTableSpesificationsResponse>
{
    private readonly ITableSpecificationRepository _tableSpecificationRepository;

    public PostTableSpesificationsHandler(ITableSpecificationRepository tableSpecificationRepository)
    {
        _tableSpecificationRepository = tableSpecificationRepository;
    }

    public async Task<PostTableSpesificationsResponse> Handle(PostTableSpesificationsQuery query, CancellationToken cancellationToken)
    {
        var newTable = new TableSpecification()
        {
         TableId = Guid.NewGuid(),
         TableNumber = query.TableNumber,
         ChairNumber = query.ChairNumber,
         TablePic = query.TablePic,
         TableType = query.TableType
        };

        var table = await _tableSpecificationRepository.Create(newTable);

        var response = new PostTableSpesificationsResponse()
        {
            TableId = table.TableId,
            ChairNumber = table.ChairNumber,
            TableNumber = table.TableNumber,
            TablePic = table.TablePic,
            TableType = table.TableType
        };

        return response;
    }
}
}

