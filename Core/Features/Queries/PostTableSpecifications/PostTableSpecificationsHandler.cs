using System;
using MediatR;
using Persistence.Models;
using Persistence.Redis;
using Persistence.Repositories;

namespace Core.Features.Queries.PostTableSpecifications
{
	public class PostTableSpecificationsHandler : IRequestHandler<PostTableSpecificationsQuery, PostTableSpecificationsResponse>
    {
        private readonly ITableSpecificationRepository _tableSpecificationRepository;
        private readonly ICacheService _cacheService;


        public PostTableSpecificationsHandler(ITableSpecificationRepository tableSpecificationRepository, ICacheService cacheService)
        {
            _tableSpecificationRepository = tableSpecificationRepository;
            _cacheService = cacheService;
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

            if (_cacheService.CheckActive())
            {
               List<TableSpecification> specifications = _tableSpecificationRepository.GetAll();
               _cacheService.Remove("tableSpecifications");
               _cacheService.Add("tableSpecifications", specifications);
            }

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

