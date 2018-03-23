// ====================================================
// More Templates: https://www.ebenmonney.com/templates
// Email: support@ebenmonney.com
// ====================================================

using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DAL.Models.Interfaces;

namespace DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public string CurrentUserId { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Day> DayOverviews { get; set; }
        public DbSet<DayEvaluation> DayEvaluations { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventEvaluation> EventEvaluations { get; set; }
        public DbSet<EventFlag> EventFlags { get; set; }
        public DbSet<EventTask> EventTasks { get; set; }

        #region [join tables]
        //public DbSet<DayEvaluationRating> DayEvaluationRatings { get; set; }
        //public DbSet<EmployeeDay> EmployeeDays { get; set; }
        //public DbSet<EventDay> EventDays { get; set; }
        //public DbSet<EventEmployee> EventEmployees { get; set; }
        //public DbSet<EventEvaluationRating> EventEvaluationRatings { get; set; }
        //public DbSet<EventEventFlag> EventEventFlags { get; set; }
        //public DbSet<EventEventTask> EventEventTasks { get; set; }
        #endregion


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().HasMany(u => u.Claims).WithOne().HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUser>().HasMany(u => u.Roles).WithOne().HasForeignKey(r => r.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationRole>().HasMany(r => r.Claims).WithOne().HasForeignKey(c => c.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationRole>().HasMany(r => r.Users).WithOne().HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Customer>().HasIndex(c => c.Name);
            builder.Entity<Customer>().Property(c => c.Email).HasMaxLength(100);
            builder.Entity<Customer>().Property(c => c.PhoneNumber).IsUnicode(false).HasMaxLength(30);
            builder.Entity<Customer>().Property(c => c.City).HasMaxLength(50);
            builder.Entity<Customer>().ToTable($"App{nameof(this.Customers)}");

            builder.Entity<ProductCategory>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Entity<ProductCategory>().Property(p => p.Description).HasMaxLength(500);
            builder.Entity<ProductCategory>().ToTable($"App{nameof(this.ProductCategories)}");

            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Product>().HasIndex(p => p.Name);
            builder.Entity<Product>().Property(p => p.Description).HasMaxLength(500);
            builder.Entity<Product>().Property(p => p.Icon).IsUnicode(false).HasMaxLength(256);
            builder.Entity<Product>().HasOne(p => p.Parent).WithMany(p => p.Children).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Product>().ToTable($"App{nameof(this.Products)}");

            builder.Entity<Order>().Property(o => o.Comments).HasMaxLength(500);
            builder.Entity<Order>().ToTable($"App{nameof(this.Orders)}");

            builder.Entity<OrderDetail>().ToTable($"App{nameof(this.OrderDetails)}");

            #region [joinTables]
            builder.Entity<DayEvaluationRating>()
                .HasKey(d => new { d.DayEvaluationId, d.RatingId });

            builder.Entity<DayEvaluationRating>()
                .HasOne(d => d.Rating)
                .WithMany("DayEvaluationRatings");

            builder.Entity<DayEvaluationRating>()
                .HasOne(d => d.DayEvaluation)
                .WithMany("DayEvaluationRatings");

            builder.Entity<EmployeeDay>()
                .HasKey(d => new { d.EmployeeId, d.DayId });

            builder.Entity<EmployeeDay>()
                .HasOne(d => d.Employee)
                .WithMany("EmployeeDays");

            builder.Entity<EmployeeDay>()
                .HasOne(d => d.Day)
                .WithMany("EmployeeDays");

            builder.Entity<EventDay>()
                .HasKey(d => new { d.EventId, d.DayId });

            builder.Entity<EventDay>()
                .HasOne(d => d.Event)
                .WithMany("EventDays");

            builder.Entity<EventDay>()
                .HasOne(d => d.Day)
                .WithMany("EventDays");

            builder.Entity<EventEmployee>()
                .HasKey(d => new { d.EventId, d.EmployeeId });

            builder.Entity<EventEmployee>()
                .HasOne(d => d.Event)
                .WithMany("EventEmployees");

            builder.Entity<EventEmployee>()
                .HasOne(d => d.Employee)
                .WithMany("EventEmployees");

            builder.Entity<EventEvaluationRating>()
                .HasKey(d => new { d.EventEvaluationId, d.RatingId });

            builder.Entity<EventEvaluationRating>()
                .HasOne(d => d.EventEvaluation)
                .WithMany("EventEvaluationRatings");

            builder.Entity<EventEvaluationRating>()
                .HasOne(d => d.Rating)
                .WithMany("EventEvaluationRatings");

            builder.Entity<EventEventFlag>()
                .HasKey(d => new { d.EventId, d.EventFlagId });

            builder.Entity<EventEventFlag>()
                .HasOne(d => d.EventFlag)
                .WithMany("EventEventFlags");

            builder.Entity<EventEventFlag>()
                .HasOne(d => d.Event)
                .WithMany("EventEventFlags");

            builder.Entity<EventEvaluationRating>()
                .HasOne(d => d.Rating)
                .WithMany("EventEvaluationRatings");

            builder.Entity<EventEventTask>()
                .HasKey(d => new { d.EventId, d.EventTaskId });

            builder.Entity<EventEventTask>()
                .HasOne(d => d.EventTask)
                .WithMany("EventEventTasks");

            builder.Entity<EventEventTask>()
                .HasOne(d => d.Event)
                .WithMany("EventEventTasks");
            #endregion
        }

        public override int SaveChanges()
        {
            UpdateAuditEntities();
            return base.SaveChanges();
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateAuditEntities();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(cancellationToken);
        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        private void UpdateAuditEntities()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));


            foreach (var entry in modifiedEntries)
            {
                var entity = (IAuditableEntity)entry.Entity;
                DateTime now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                    entity.CreatedBy = CurrentUserId;
                }
                else
                {
                    base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                }

                entity.UpdatedDate = now;
                entity.UpdatedBy = CurrentUserId;
            }
        }
    }
}
