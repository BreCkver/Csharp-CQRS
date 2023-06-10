using CSharp_CQRS_Example.Application.DTOs;
using CSharp_CQRS_Example.Infrastructure.Commands;
using CSharp_CQRS_Example.Infrastructure.Data;
using MediatR;

namespace CSharp_CQRS_Example.Application.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, TaskItemDTO>
    {

        private readonly ApplicationDbContext _dbContext;

        public UpdateTaskHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskItemDTO> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
           var taskItem = await _dbContext.TaskItems.FindAsync(
            new object[] { request.Id }, cancellationToken);


            if(taskItem == null)
            {
                return await Task.FromResult<TaskItemDTO>(new TaskItemDTO{});
            }

            taskItem.Title = request.Title;
            taskItem.Description = request.Description;
            taskItem.IsCompleted = request.IsCompleted;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new TaskItemDTO{
                Description = taskItem.Description,
                Id = taskItem.Id, 
                IsCompleted = taskItem.IsCompleted, 
                Title = taskItem.Title,
            } ;
        }
    }
}