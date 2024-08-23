using MediatR;
using Persistence.Models;
using Persistence.Redis;
using Persistence.Repositories;

namespace Core.Features.Queries.GetTableSpecifications;

public class GetTableSpecificationsHandler : IRequestHandler<GetTableSpecificationsQuery, GetTableSpecificationsResponse>
{
    private readonly ITableSpecificationRepository _tableSpecificationRepository;
    private readonly ICacheService _cacheService;

    public GetTableSpecificationsHandler(ITableSpecificationRepository tableSpecificationRepository, ICacheService cacheService)
    {
        _tableSpecificationRepository = tableSpecificationRepository;
        _cacheService = cacheService;
    }

    public async Task<GetTableSpecificationsResponse> Handle(GetTableSpecificationsQuery query, CancellationToken cancellationToken)
    {
        List<TableSpecification>? tableSpecification = _cacheService.Get<TableSpecification>("tableSpecifications");
        if (tableSpecification is null)
        {
            if (_cacheService.CheckActive())
            {
                List<TableSpecification> specifications = _tableSpecificationRepository.GetAll();
                _cacheService.Add("tableSpecifications", specifications);
            }
            tableSpecification = new List<TableSpecification>
            { _tableSpecificationRepository.GetById(query.TableId) };
        }

        var res = tableSpecification.Find(o => o.TableId.Equals(query.TableId));
   

        if (tableSpecification is null)
            return new GetTableSpecificationsResponse();
        
        var response = new GetTableSpecificationsResponse()
        {
            TableId = res.TableId,
            ChairNumber = res.ChairNumber,
            TableNumber = res.TableNumber,
            TablePic = res.TablePic,
            TableType = res.TableType
        };
        
        return response;
    }
}