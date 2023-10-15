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

    public async Task<Todo> CreateTodoAsync(Todo todo)
    {
        _context.Todos.Add(todo);
        _context.SaveChanges();
        await _context.SaveChangesAsync();

        return todo;
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
