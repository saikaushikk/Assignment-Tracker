using Microsoft.EntityFrameworkCore;

namespace AssignmentTracker.Data
{
    public class AssignmentTrackerContext : DbContext
    {
        public AssignmentTrackerContext (
            DbContextOptions<AssignmentTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<AssignmentTracker.Models.Assignment> Assignment { get; set; }
    }
}