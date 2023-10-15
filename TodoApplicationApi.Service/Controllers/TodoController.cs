using System;
using Microsoft.AspNetCore.Mvc;
using TodoApplicationApi.TodoApplicationApi.Contracts.Base;
using TodoApplicationApi.TodoApplicationApi.Contracts.Create;
using TodoApplicationApi.TodoApplicationApi.Contracts.Update;
using TodoApplicationApi.TodoApplicationApi.DataModel.Models;
using TodoApplicationApi.TodoApplicationApi.Exceptions;
using TodoApplicationApi.TodoApplicationApi.Interfaces.TodoInterfaces;

namespace TodoApplicationApi.TodoApplicationApi.Service.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TodoController : ControllerBase
{

	private readonly TodoInterface _todoService;

	public TodoController(TodoInterface todoService)
	{
		_todoService = todoService;
	}

	[HttpGet]

	public async Task<ActionResult<BaseResponseContract<Todo>>> GetAllTodosAsync()
	{
		BaseResponseContract<List<Todo>> response = new BaseResponseContract<List<Todo>>();

		try
		{
			List<Todo> todos = await _todoService.GetAllTodosAsync();

			response.Data = todos;
			response.Success = true;

			return Ok(response);
		}
		catch(EntityNotFoundException e)
		{
			response.Message = e.Message;
			response.Success = false;

			return NotFound(response);
		}
		catch(Exception e)
		{
			response.Message = e.Message;
			response.Success = false;

			return StatusCode(StatusCodes.Status500InternalServerError, response);
		}
	}

	[HttpGet("{id}")]

	public async Task<ActionResult<BaseResponseContract<Todo>>> GetTodoByIdAsync(int id)
	{
		BaseResponseContract<Todo> response = new BaseResponseContract<Todo>();

		try
		{
			Todo todo = await _todoService.GetTodoByIdAsync(id);

			response.Data = todo;
			response.Message = "Successfully retrieved todo";
			response.Success = true;

			return Ok(response);
		}
		catch(EntityNotFoundException e)
		{
			response.Message = e.Message;
			response.Success = false;

			return NotFound(response);
		}
		catch(Exception e)
		{
			response.Message = e.Message;
			response.Success = false;

			return StatusCode(StatusCodes.Status500InternalServerError, response);
		}
	}

	[HttpPost]

	public async Task<ActionResult<BaseResponseContract<Todo>>> CreateTodoAsync([FromBody] CreateTodoContract createTodoContract)
	{
		BaseResponseContract<Todo> response = new BaseResponseContract<Todo>();

		try
		{
			Todo todo = new Todo()
			{
				Title = createTodoContract.Title,
				CreatedAt = DateTime.UtcNow,
				UpdatedAt = DateTime.UtcNow
			};

			response.Data = await _todoService.CreateTodoAsync(todo);
			response.Success = true;
			response.Message = "Todo created successfully";

			return Ok(response);
		}
		catch(EntityNotFoundException e)
		{
			response.Success = false;
			response.Message = e.Message;

			return NotFound(response);
		}
		catch(Exception e)
		{
			response.Success = false;
			response.Message = e.Message;

			return StatusCode(StatusCodes.Status500InternalServerError, response);
		}
	}

	[HttpPut("{id}")]

	public async Task<ActionResult<BaseResponseContract<Todo>>> UpdateTodoAsync([FromBody] UpdateTodoContract updateTodoContract, int id)
	{
		BaseResponseContract<Todo> response = new BaseResponseContract<Todo>();

		try
		{
			Todo todo = new Todo()
			{
				Id = id,
				Title = updateTodoContract.Title,
				UpdatedAt = DateTime.UtcNow
			};

			response.Data = await _todoService.UpdateTodoAsync(todo);
			response.Message = "Successfully Updated Todo";
			response.Success = true;

			return Ok(response);
		}
        catch (EntityNotFoundException e)
        {
            response.Success = false;
            response.Message = e.Message;

            return NotFound(response);
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;

            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }
		
}