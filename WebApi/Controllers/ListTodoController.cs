using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ListTodoController : ControllerBase
{
    private ListTodoService _listTodoService;
    public ListTodoController(ListTodoService listTodoService)
    {
        _listTodoService = listTodoService;
    }

    [HttpGet("ListTodo")]
    public List<ListTodoDto> ListTodo()
    {
        return _listTodoService.ListTodo();
    }

    [HttpGet("Get By Id")]
    public ListTodoDto GetListTodoById(int Id)
    {
        return _listTodoService.GetListTodoById(Id);
    }

    [HttpPost("AddListTodo")]
    public ListTodoDto AddListTodo(ListTodoDto listTodo)
    {
        return _listTodoService.AddListTodo(listTodo);
    }

    [HttpPut("Update")]
    public ListTodoDto UpdateListTodo(ListTodoDto listTodo)
    {
        return _listTodoService.UpdateListTodo(listTodo);
    }

    [HttpDelete("Delete")]
    public ListTodoDto DeleteListTodo(ListTodoDto listTodo)
    {
        return _listTodoService.DeleteListTodo(listTodo);
    }

    [HttpGet("FilterByName")]
    public List<ListTodoDto> FilterListTodoName(string task_name)
    {
        return _listTodoService.FilterListTodoName(task_name);
    }

    [HttpGet("FilterByStatus")]
    public List<ListTodoDto> FilterListTodoStatus(int status)
    {
        return _listTodoService.FilterListTodoStatus(status);
    }
}
