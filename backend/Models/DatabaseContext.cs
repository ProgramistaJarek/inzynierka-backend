using Microsoft.EntityFrameworkCore;
using backend.ModelsDTO;

namespace backend.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> User { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt) { }
    }
}
