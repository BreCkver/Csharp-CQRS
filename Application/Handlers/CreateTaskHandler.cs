using CSharp_CQRS_Example.Application.DTOs;
using CSharp_CQRS_Example.Domain;
using CSharp_CQRS_Example.Infrastructure.Commands;
using CSharp_CQRS_Example.Infrastructure.Data;
using MediatR;

namespace CSharp_CQRS_Example.Application.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, TaskItemDTO>
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateTaskHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskItemDTO> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = new TaskItem
            {
                Title = request.Title,
                Description = request.Description
            };

            _dbContext.TaskItems?.Add(taskItem);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new TaskItemDTO
            {
                Id = taskItem.Id,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted,
                Title = taskItem.Title,
            };
        }
    }
}