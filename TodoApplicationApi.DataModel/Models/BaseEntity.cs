using System;
namespace TodoApplicationApi.TodoApplicationApi.DataModel.Models
{
	public abstract class BaseEntity
	{

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

	}
}

