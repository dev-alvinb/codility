using Microsoft.EntityFrameworkCore;
using Codility2.Models;

namespace Codility2.Data
{
    public class ManagerContext : DbContext
    {
        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {
        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<ApplicantJob> ApplicantJobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicantJob>()
                .HasKey(aj => new { aj.ApplicantId, aj.JobId });

            modelBuilder.Entity<ApplicantJob>()
            .HasOne(aj => aj.Applicant)
            .WithMany(a => a.ApplicantJobs)
            .HasForeignKey(aj => aj.ApplicantId);

            modelBuilder.Entity<ApplicantJob>()
            .HasOne(aj => aj.Job)
            .WithMany(j => j.ApplicantJobs)
            .HasForeignKey(aj => aj.JobId);

        }
    }
}
