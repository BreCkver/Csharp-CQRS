using CSharp_CQRS_Example.Application.DTOs;
using MediatR;

namespace CSharp_CQRS_Example.Infrastructure.Commands;

public record DeleteTaskCommand(int Id) : IRequest<bool>;

