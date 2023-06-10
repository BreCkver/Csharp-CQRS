using CSharp_CQRS_Example.Application.DTOs;
using MediatR;

namespace CSharp_CQRS_Example.Infrastructure.Commands;

public record CreateTaskCommand(string Title, string Description) : IRequest<TaskItemDTO>;
