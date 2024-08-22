using Core.Features.Queries.DeleteTableSpecifications;
using MediatR;

namespace Core.Features.Queries.GetTableSpecifications;

public class DeleteTableSpecificationsQuery : IRequest<DeleteTableSpecificationsResponse>
{
    public Guid TableId { get; set; }
}