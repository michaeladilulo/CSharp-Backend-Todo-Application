using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApplicationApi.TodoApplicationApi.Contracts.Create
{
	public class CreateTodoContract
	{

		[Required]
		[StringLength(25, MinimumLength = 5)]
		public string Title { get; set; }

	}
}

