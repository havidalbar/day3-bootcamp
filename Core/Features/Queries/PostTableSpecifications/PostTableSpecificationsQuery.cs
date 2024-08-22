using System;
using MediatR;

namespace Core.Features.Queries.PostTableSpecifications
{
	public class PostTableSpecificationsQuery : IRequest<PostTableSpecificationsResponse>
    {
        public int TableNumber { get; set; }
        public int ChairNumber { get; set; }
        public string TablePic { get; set; }
        public string? TableType { get; set; }
    }
}

