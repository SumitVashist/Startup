using Microsoft.EntityFrameworkCore;
using Startup.Models;

namespace Startup.Models
{
    public class TrainingCenterDbContext : DbContext
    {
        public TrainingCenterDbContext(DbContextOptions<TrainingCenterDbContext> options) : base(options)
        {
        }


  
        
        public DbSet<TrainingCenter> TrainingCenters { get; set; }
    }

}