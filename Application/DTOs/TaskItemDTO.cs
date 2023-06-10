namespace CSharp_CQRS_Example.Application.DTOs;
public class TaskItemDTO
{
    public int Id { set; get; }
    public string? Title { set; get; }
    public string? Description { set; get; }
    public bool IsCompleted { set; get; }
}
