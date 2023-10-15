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

    public async Task<Todo> CreateTodoAsync(Todo todo)
    {
        return await _todoRepository.CreateTodoAsync(todo);
    }

    public async Task DeleteTodoByIdAsync(int id)
    {
        Todo todo = await _todoRepository.GetTodoByIdAsync(id);

        if(todo == null)
        {
            throw new EntityNotFoundException($"Todo with the ID {id} could not be found");
        }

        await _todoRepository.DeleteTodoByIdAsync(todo);
    }

    public async Task<List<Todo>> GetAllTodosAsync()
    {
        List<Todo> todos = await _todoRepository.GetAllTodosAsync() ?? throw new EntityNotFoundException($"Todos Not Found");

        return todos;
    }

    public async Task<Todo> GetTodoByIdAsync(int id)
    {
        Todo todo = await _todoRepository.GetTodoByIdAsync(id);

        if(todo == null)
        {
            throw new EntityNotFoundException($"Todo with id {id} could not be found");
        }

        return todo;
    }

    public async Task<Todo> UpdateTodoAsync(Todo todo)
    {
        return await _todoRepository.UpdateTodoAsync(todo);
    }
}
