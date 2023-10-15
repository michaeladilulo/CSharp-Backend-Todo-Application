using System;
using Microsoft.EntityFrameworkCore;
using TodoApplicationApi.TodoApplicationApi.DataModel;
using TodoApplicationApi.TodoApplicationApi.DataModel.Models;
using TodoApplicationApi.TodoApplicationApi.Interfaces.Repositories;

namespace TodoApplicationApi.TodoApplicationApi.Data.Repository;

public class TodoRepository : ITodoRepository
{

	private readonly DatabaseContext _context;

	public TodoRepository(DatabaseContext context)
	{
		_context = context;
	}

    public Task<Todo> CreateTodoAsync(Todo todo)
    {
        throw new NotImplementedException();
    }

    public Task<Todo> DeleteTodoByIdAsync(Todo todo)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Todo>> GetAllTodosAsync()
    {
        return await _context.Todos.ToListAsync();
    }

    public async Task<Todo> GetTodoByIdAsync(int id)
    {
        return await _context.Todos.FindAsync(id);
    }

    public Task<Todo> UpdateTodoAsync(Todo todo)
    {
        throw new NotImplementedException();
    }
}
