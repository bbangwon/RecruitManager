using Microsoft.EntityFrameworkCore;
using RecruitManager.Models;

namespace RecruitManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<RecruitSetting>? RecruitSettings { get; set; }
        public DbSet<RecruitRegistration>? RecruitRegistrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var recruitSetting = modelBuilder.Entity<RecruitSetting>();

            recruitSetting
                .Property(rs => rs.CreationDate)
                .HasDefaultValueSql("GetDate()");

            recruitSetting
                .Property(rs => rs.StartDate)
                .HasColumnType("SmallDateTime");

            recruitSetting
                .Property(rs => rs.EventDate)
                .HasColumnType("SmallDateTime");

            recruitSetting
                .Property(rs => rs.EndDate)
                .HasColumnType("SmallDateTime");

            recruitSetting
                .Property(rs => rs.MaxCount)
                .HasDefaultValue(1000);




            var recruitRegistrations = modelBuilder.Entity<RecruitRegistration>();

            recruitRegistrations
                .Property(rr => rr.CreationDate)
                .HasDefaultValueSql("GetDate()");

            base.OnModelCreating(modelBuilder);
        }
    }
}
