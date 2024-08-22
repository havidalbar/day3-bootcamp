using Core.Features.Queries.GetTableSpecifications;
using MediatR;
using Persistence.Repositories;

namespace Core.Features.Queries.DeleteTableSpecifications;

public class DeleteTableSpecificationsHandler : IRequestHandler<DeleteTableSpecificationsQuery, DeleteTableSpecificationsResponse>
{
    private readonly ITableSpecificationRepository _tableSpecificationRepository;

    public DeleteTableSpecificationsHandler(ITableSpecificationRepository tableSpecificationRepository)
    {
        _tableSpecificationRepository = tableSpecificationRepository;
    }

    public async Task<DeleteTableSpecificationsResponse?> Handle(DeleteTableSpecificationsQuery query, CancellationToken cancellationToken)
    {
        var tableSpecification = _tableSpecificationRepository.GetById(query.TableId);

        if (tableSpecification is null)
            return null;

        await _tableSpecificationRepository.Delete(tableSpecification);

        var response = new DeleteTableSpecificationsResponse()
        {
            Status = "Success"
        };

        return response;
    }
}