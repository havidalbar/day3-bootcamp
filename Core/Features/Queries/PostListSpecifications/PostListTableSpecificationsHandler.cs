using System;
using Core.Features.Queries.PostListSpecifications;
using MediatR;
using Persistence.Models;
using Persistence.Redis;
using Persistence.Repositories;

namespace Core.Features.Queries.PostTableSpecifications
{
	public class PostListTableSpecificationsHandler : IRequestHandler<PostListTableSpecificationsQuery, Object>
{
    private readonly ITableSpecificationRepository _tableSpecificationRepository;
    private readonly ICacheService _cacheService;

    public PostListTableSpecificationsHandler(ITableSpecificationRepository tableSpecificationRepository, ICacheService cacheService)
    {
        _tableSpecificationRepository = tableSpecificationRepository;
        _cacheService = cacheService;
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

        if (_cacheService.CheckActive())
        {
            List<TableSpecification> specifications = _tableSpecificationRepository.GetAll();
            _cacheService.Remove("tableSpecifications");
            _cacheService.Add("tableSpecifications", specifications);
        }

        return tableSpecifications;
    }
}
}

