namespace Domain.Dtos;

public class ListTodoDto
{
    public int Id { get; set; }
    public string? TaskName { get; set; }
    public Status Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

public enum Status
{
    Todo =1,
    InProgres =2,
    Complete = 3
}