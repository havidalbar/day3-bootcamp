using System;
using MediatR;
using Persistence.Models;
using Persistence.Repositories;

namespace Core.Features.Queries.PostTableSpecifications
{
	public class PostTableSpecificationsHandler : IRequestHandler<PostTableSpecificationsQuery, PostTableSpecificationsResponse>
{
    private readonly ITableSpecificationRepository _tableSpecificationRepository;

    public PostTableSpecificationsHandler(ITableSpecificationRepository tableSpecificationRepository)
    {
        _tableSpecificationRepository = tableSpecificationRepository;
    }

    public async Task<PostTableSpecificationsResponse> Handle(PostTableSpecificationsQuery query, CancellationToken cancellationToken)
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

        var response = new PostTableSpecificationsResponse()
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

