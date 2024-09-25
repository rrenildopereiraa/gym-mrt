using Microsoft.EntityFrameworkCore;
using GymManagementAPI.Models;

namespace GymManagementAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Workout> Workouts { get; set; }
    }
}
