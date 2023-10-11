using System;
using TodoApplicationApi.TodoApplicationApi.DataModel.Models;

namespace TodoApplicationApi.TodoApplicationApi.Interfaces.TodoInterfaces
{
	public interface TodoInterface
	{

		public Task<List<Todo>> GetAllTodosAsync();

		public Task<Todo> GetTodoByIdAsync(int id);

		public Task<Todo> CreateTodoAsync(Todo todo);

		public Task<Todo> UpdateTodoAsync(Todo todo);

		public Task DeleteTodoByIdAsync(int id);

	}
}

