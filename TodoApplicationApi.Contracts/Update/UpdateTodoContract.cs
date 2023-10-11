using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApplicationApi.TodoApplicationApi.Contracts.Update
{
	public class UpdateTodoContract
	{

		[Required]

		public int Id { get; set; }

	}
}

