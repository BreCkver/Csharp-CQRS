using CSharp_CQRS_Example.Application.DTOs;
using CSharp_CQRS_Example.Infrastructure.Data;
using CSharp_CQRS_Example.Infrastructure.Queries;
using MediatR;

namespace CSharp_CQRS_Example.Application.Handlers
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskItemDTO>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetTaskByIdHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskItemDTO> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var taskItem = await _dbContext.TaskItems.FindAsync(
                new object[] { request.id, cancellationToken});

            if (taskItem == null)
            {
                return await Task.FromResult<TaskItemDTO>(new TaskItemDTO{});
            }

            return new TaskItemDTO{
                Description = taskItem.Description,
                Id = taskItem.Id,
                IsCompleted = taskItem.IsCompleted, 
                Title = taskItem.Title
            };

        }
    }
}