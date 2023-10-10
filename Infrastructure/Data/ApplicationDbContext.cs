using CSharp_CQRS_Example.Domain;
using Microsoft.EntityFrameworkCore;

namespace CSharp_CQRS_Example.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TaskItem>? TaskItems { set; get; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
        {
            
        }
    }
}