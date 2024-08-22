using System;
using Core.Features.Queries.PostTableSpecifications;
using MediatR;
using Persistence.Models;
using Persistence.Repositories;

namespace Core.Features.Queries.PutTableSpecifications
{
    public class PutTableSpecificationsHandler : IRequestHandler<PutTableSpecificationsQuery, PostTableSpecificationsResponse>
    {
        private readonly ITableSpecificationRepository _tableSpecificationRepository;

        public PutTableSpecificationsHandler(ITableSpecificationRepository tableSpecificationRepository)
        {
            _tableSpecificationRepository = tableSpecificationRepository;
        }

        public async Task<PostTableSpecificationsResponse> Handle(PutTableSpecificationsQuery query, CancellationToken cancellationToken)
        {
            var oldTable = _tableSpecificationRepository.GetById(query.TableId);

            if (oldTable is null)
            {
                return new PostTableSpecificationsResponse();
            }

            oldTable.TableNumber = query.TableNumber;
            oldTable.ChairNumber = query.ChairNumber;
            oldTable.TablePic = query.TablePic;
            oldTable.TableType = query.TableType;

            await _tableSpecificationRepository.Update(oldTable);

            var response = new PostTableSpecificationsResponse()
            {
                TableId = oldTable.TableId,
                ChairNumber = oldTable.ChairNumber,
                TableNumber = oldTable.TableNumber,
                TablePic = oldTable.TablePic,
                TableType = oldTable.TableType
            };

            return response;
        }
    }
}

