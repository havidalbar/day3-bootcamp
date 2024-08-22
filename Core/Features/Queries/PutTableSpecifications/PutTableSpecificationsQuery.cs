using System;
using Core.Features.Queries.PostTableSpecifications;
using MediatR;

namespace Core.Features.Queries.PutTableSpecifications
{
	public class PutTableSpecificationsQuery : IRequest<PostTableSpecificationsResponse>
    {
        public Guid TableId { get; set; }
        public int TableNumber { get; set; }
        public int ChairNumber { get; set; }
        public string TablePic { get; set; }
        public string TableType { get; set; }
    }
}

