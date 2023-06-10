using CSharp_CQRS_Example.Infrastructure.Commands;
using CSharp_CQRS_Example.Infrastructure.Data;
using MediatR;

namespace CSharp_CQRS_Example.Application.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteTaskHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _dbContext.TaskItems.FindAsync(
                new object[] { request.Id }, cancellationToken);

            if (taskItem == null)
            {
                return false;
            }
            _dbContext.TaskItems.Remove(taskItem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}