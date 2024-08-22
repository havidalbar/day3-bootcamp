using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Core.Features.Queries.PostTableSpesifications
{
	public class PostTableSpesificationsQuery : IRequest<PostTableSpesificationsResponse>
    {
        public int TableNumber { get; set; }
        public int ChairNumber { get; set; }
        public string TablePic { get; set; }
        public string? TableType { get; set; }
    }
}

