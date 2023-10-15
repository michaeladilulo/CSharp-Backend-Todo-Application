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

    public async Task DeleteTodoByIdAsync(Todo todo)
    {
        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Todo>> GetAllTodosAsync()
    {
        return await _context.Todos.ToListAsync();
    }

    public async Task<Todo> GetTodoByIdAsync(int id)
    {
        return await _context.Todos.FindAsync(id);
    }

    public async Task<Todo> UpdateTodoAsync(Todo todo)
    {
        Todo updatedTodo = _context.Todos.First(t => t.Id == todo.Id);
        updatedTodo.Title = todo.Title;

        await _context.SaveChangesAsync();
        return updatedTodo;
    }
}
