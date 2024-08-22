using System;
using Core.Features.Queries.PostListSpecifications;
using MediatR;
using Persistence.Models;
using Persistence.Repositories;

namespace Core.Features.Queries.PostTableSpecifications
{
	public class PostListTableSpecificationsHandler : IRequestHandler<PostListTableSpecificationsQuery, Object>
{
    private readonly ITableSpecificationRepository _tableSpecificationRepository;

    public PostListTableSpecificationsHandler(ITableSpecificationRepository tableSpecificationRepository)
    {
        _tableSpecificationRepository = tableSpecificationRepository;
    }

    public async Task<Object> Handle(PostListTableSpecificationsQuery query, CancellationToken cancellationToken)
    {
       List<TableSpecification> tableSpecifications = new List<TableSpecification>(); 
       foreach (TableSpecificationEntity q in query.TableSpecifications.ToList())
       {
          var newTable = new TableSpecification()
          {
          TableId = Guid.NewGuid(),
          TableNumber = q.TableNumber,
          ChairNumber = q.ChairNumber,
          TablePic = q.TablePic,
          TableType = q.TableType
          };

          tableSpecifications.Add(newTable);
       }

        await _tableSpecificationRepository.CreateBatch(tableSpecifications);


        return tableSpecifications;
    }
}
}

