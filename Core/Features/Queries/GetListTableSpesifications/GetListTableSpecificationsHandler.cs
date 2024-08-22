using System.Text.Json;
using Core.Features.Queries.GetTableSpecifications;
using MediatR;
using Persistence.Models;
using Persistence.Repositories;

namespace Core.Features.Queries.GetListTableSpecifications;

public class GetListTableSpecificationsHandler : IRequestHandler<GetListTableSpecificationsQuery, Object>
{
    private readonly ITableSpecificationRepository _tableSpecificationRepository;

    public GetListTableSpecificationsHandler(ITableSpecificationRepository tableSpecificationRepository)
    {
        _tableSpecificationRepository = tableSpecificationRepository;
    }

    public async Task<Object> Handle(GetListTableSpecificationsQuery query, CancellationToken cancellationToken)
    {
        List<TableSpecification> tableSpecifications = _tableSpecificationRepository.GetAll();
        
        if (tableSpecifications is null)
            return new List<TableSpecification>();

        return tableSpecifications;
    }
}