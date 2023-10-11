using System;
namespace TodoApplicationApi.TodoApplicationApi.Contracts.Base
{
	public class BaseResponseContract<T>
	{

		public bool Success { get; set; }

		public string? Message { get; set; }

		public T? Data { get; set; }

	}
}

