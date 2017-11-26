namespace BackLogApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel")
        {
        }

        public virtual DbSet<BackLog> BackLogs { get; set; }
        public virtual DbSet<Line> Lines { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Text> Texts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BackLog>()
                .Property(e => e.Label)
                .IsUnicode(false);

            modelBuilder.Entity<BackLog>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<BackLog>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.BackLog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Line>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Line>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Label)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .HasMany(e => e.Texts)
                .WithRequired(e => e.Task)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Text>()
                .Property(e => e.Label)
                .IsUnicode(false);

            modelBuilder.Entity<Text>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Text>()
                .HasMany(e => e.Lines)
                .WithRequired(e => e.Text1)
                .WillCascadeOnDelete(false);
        }
    }
}
