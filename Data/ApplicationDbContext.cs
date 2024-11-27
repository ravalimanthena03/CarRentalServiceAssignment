using Microsoft.EntityFrameworkCore;
using CarRentalServiceAssignment.Models;
namespace CarRentalServiceAssignment.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
