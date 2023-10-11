using System;
using TodoApplicationApi.TodoApplicationApi.DataModel.Models;
using TodoApplicationApi.TodoApplicationApi.Exceptions;
using TodoApplicationApi.TodoApplicationApi.Interfaces.Repositories;
using TodoApplicationApi.TodoApplicationApi.Interfaces.TodoInterfaces;

namespace TodoApplicationApi.TodoApplicationApi.Business.Services;

public class TodoService : TodoInterface
{
	private readonly ITodoRepository _todoRepository;

	public TodoService(ITodoRepository todoRepository)
	{
		_todoRepository = todoRepository;
	}

    public Task<Todo> CreateTodoAsync(Todo todo)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTodoByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Todo>> GetAllTodosAsync()
    {
        List<Todo> todos = await _todoRepository.GetAllTodosAsync() ?? throw new EntityNotFoundException($"Todos Not Found");

        return todos;
    }

    public Task<Todo> GetTodoByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Todo> UpdateTodoAsync(Todo todo)
    {
        throw new NotImplementedException();
    }
}
