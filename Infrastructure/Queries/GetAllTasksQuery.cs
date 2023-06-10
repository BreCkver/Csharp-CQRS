using CSharp_CQRS_Example.Application.DTOs;
using MediatR;

namespace CSharp_CQRS_Example.Infrastructure.Queries;

public record GetAllTasksQuery : IRequest<IEnumerable<TaskItemDTO>>;