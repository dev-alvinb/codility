using Microsoft.EntityFrameworkCore;
using Codility.Models;

namespace Codility.Data
{
    public class ManagerContext: DbContext
    {
        public ManagerContext(DbContextOptions<ManagerContext> options): base(options) { }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
