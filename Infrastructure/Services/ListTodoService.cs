using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class ListTodoService
{
    private DapperContext _context;
    public ListTodoService(DapperContext context)
    {
        _context = context;
    }

    // List 
    public List<ListTodoDto> ListTodo()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, task_name as TaskName, status as Status, start_date as StartDate, end_date as EndDate from ListTodo";
            var result = conn.Query<ListTodoDto>(sql).ToList();
            return result.ToList();
        }
    }

    // Get By Id
    public ListTodoDto GetListTodoById(int Id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, task_name as TaskName, status as Status, start_date as StartDate, end_date as EndDate from ListTodo where id = {Id}";
            var result = conn.QuerySingle<ListTodoDto>(sql);
            return result;
        }
    }

    // Insert
    public ListTodoDto AddListTodo(ListTodoDto listTodo)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into ListTodo (task_name, status, start_date, end_date) values (@TaskName, @Status, @StartDate, @EndDate)";
            var result = conn.Execute(sql, listTodo);
            return listTodo;
        }
    }
    // Update
    public ListTodoDto UpdateListTodo(ListTodoDto listTodo)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Update ListTodo set task_name = @TaskName, status = @Status, start_date = @StartDate, end_date = @EndDate where id = @Id";
            var result = conn.Execute(sql, listTodo);
            return listTodo;
        }
    }

    // Delete
    public ListTodoDto DeleteListTodo(ListTodoDto listTodo)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from ListTodo where id = @Id";
            var result = conn.Execute(sql, listTodo);
            return listTodo;
        }
    }
    
    // FilterByName
    public List<ListTodoDto> FilterListTodoName(string task_name)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, task_name as TaskName, status as Status, start_date as StartDate, end_date as EndDate from  listtodo where task_name like '%{task_name}%'";
            var result = conn.Query<ListTodoDto>(sql).ToList();
            return result.ToList();
        }
    }

    // FilterByStatus
    public List<ListTodoDto> FilterListTodoStatus(int status)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, task_name as TaskName, status as Status, start_date as StartDate, end_date as EndDate from  listtodo where status = {status}";
            var result = conn.Query<ListTodoDto>(sql).ToList();
            return result;
        }
    }



}
