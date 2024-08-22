using System;
using MediatR;

namespace Core.Features.Queries.PostListSpecifications
{
	public class PostListTableSpecificationsQuery : IRequest<Object>
    {
        public List<TableSpecificationEntity> TableSpecifications { get; set; }
    }

    public class TableSpecificationEntity
    {
        public int TableNumber { get; set; }
        public int ChairNumber { get; set; }
        public string TablePic { get; set; }
        public string TableType { get; set; }
    }
}

