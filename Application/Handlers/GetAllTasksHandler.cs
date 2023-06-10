using CSharp_CQRS_Example.Application.DTOs;
using CSharp_CQRS_Example.Infrastructure.Data;
using CSharp_CQRS_Example.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CSharp_CQRS_Example.Application.Handlers
{
    public class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskItemDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetAllTasksHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TaskItemDTO>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _dbContext.TaskItems.ToListAsync(cancellationToken);
            return tasks.Select( t => new TaskItemDTO {
                Id = t.Id, 
                Description = t.Description, 
                Title = t.Title, 
                IsCompleted = t.IsCompleted,
            }).ToList();
        }
    }
}