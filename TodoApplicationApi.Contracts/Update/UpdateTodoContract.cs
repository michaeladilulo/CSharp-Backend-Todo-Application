using System;
using System.ComponentModel.DataAnnotations;
using TodoApplicationApi.TodoApplicationApi.Contracts.Create;

namespace TodoApplicationApi.TodoApplicationApi.Contracts.Update
{
	public class UpdateTodoContract : CreateTodoContract
	{

		[Required]
		public string Title { get; set; }

	}
}

