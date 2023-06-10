using CSharp_CQRS_Example.Application.DTOs;
using MediatR;

namespace CSharp_CQRS_Example.Infrastructure.Commands;

public record UpdateTaskCommand(int Id, string Title, string Description, bool IsCompleted) 
: IRequest<TaskItemDTO>;
