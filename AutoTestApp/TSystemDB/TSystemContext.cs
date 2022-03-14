using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestApp
{
    public class TSystemContext : DbContext
    {
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestResult> TestResults { get; set; }

        public string DbPath { get; }
        public static bool IsChanged = false;

        public TSystemContext()
        {
            DbPath = "tsystem.db";
            Database.EnsureCreated();
        }

        public override int SaveChanges()
        {
            IsChanged = true;
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}").EnableSensitiveDataLogging();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>()
                .HasMany(p => p.Solutions)
                .WithOne(s => s.Participant)
                .HasForeignKey(s => s.ParticipantId);

            modelBuilder.Entity<Problem>()
                .HasMany(p => p.Solutions)
                .WithOne(s => s.Problem)
                .HasForeignKey(s => s.ProblemId);

            modelBuilder.Entity<Problem>()
                .HasMany(p => p.Tests)
                .WithOne(t => t.Problem)
                .HasForeignKey(t => t.ProblemId);

            modelBuilder.Entity<Test>()
                .HasMany(t => t.TestResults)
                .WithOne(t => t.Test)
                .HasForeignKey(t => t.TestId);

            modelBuilder.Entity<Solution>()
                .HasMany(t => t.TestResults)
                .WithOne(s => s.Solution)
                .HasForeignKey(t => t.SolutionId);
        }
    }
}
