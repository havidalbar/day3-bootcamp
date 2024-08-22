using System;
namespace Core.Features.Queries.PostTableSpecifications
{
	public class PostTableSpecificationsResponse
	{
        public Guid TableId { get; set; }
        public int TableNumber { get; set; }
        public int ChairNumber { get; set; }
        public string TablePic { get; set; }
        public string TableType { get; set; }
    }
}

