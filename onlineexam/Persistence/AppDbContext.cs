using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using onlineexam.Models;
using onlineexam.Models.Quiz;
using System.Linq;

namespace onlineexam.Persistence
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string,
                                IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,
                                IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public virtual DbSet<Identity> Identities { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Batch> Batches { get; set; }

        public virtual DbSet<Semester> Semesters { get; set; }

        public virtual DbSet<FileModel> FileModels { get; set; }

        public virtual DbSet<InfoModel> InfoModels { get; set; }


        public virtual DbSet<Test> Tests { get; set; }

        public virtual DbSet<TestQuestion> TestQuestions { get; set; }


        public virtual DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }


            modelBuilder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });

            modelBuilder.Entity<Semester>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.Courses)
                    .WithOne(e => e.Semesters)
                    .HasForeignKey(ur => ur.SemesterId)
                    .IsRequired();
            });

        }
    }
}
