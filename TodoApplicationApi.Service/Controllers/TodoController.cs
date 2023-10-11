using System;
using Microsoft.AspNetCore.Mvc;
using TodoApplicationApi.TodoApplicationApi.Contracts.Base;
using TodoApplicationApi.TodoApplicationApi.DataModel.Models;
using TodoApplicationApi.TodoApplicationApi.Exceptions;
using TodoApplicationApi.TodoApplicationApi.Interfaces.TodoInterfaces;

namespace TodoApplicationApi.TodoApplicationApi.Service.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TodoController : ControllerBase
{

	private readonly TodoInterface _todoInterface;

	public TodoController(TodoInterface todoInterface)
	{
		_todoInterface = todoInterface;
	}

	[HttpGet]

	public async Task<ActionResult<BaseResponseContract<Todo>>> GetAllTodosAsync()
	{
		BaseResponseContract<List<Todo>> response = new BaseResponseContract<List<Todo>>();

		try
		{
			List<Todo> todos = await _todoInterface.GetAllTodosAsync();

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
		
}