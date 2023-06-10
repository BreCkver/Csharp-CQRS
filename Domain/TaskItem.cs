namespace CSharp_CQRS_Example.Domain;
public class TaskItem
{
    public int Id { set; get; }
    public string? Title { set; get; }
    public string? Description { set; get; }
    public bool IsCompleted { set; get; }
}