using Microsoft.EntityFrameworkCore;

namespace Academy.Models
{
	public class AcademyContext : DbContext
	{
		public AcademyContext(DbContextOptions<AcademyContext> options) : base(options) { }

		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Direction> Directions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>().ToTable("Students");
			modelBuilder.Entity<Teacher>().ToTable("Teachers");
			modelBuilder.Entity<Group>().ToTable("Groups");
			modelBuilder.Entity<Direction>().ToTable("Directions");

			// Настройка связей
			modelBuilder.Entity<Student>()
				.HasOne(s => s.Group)
				.WithMany(g => g.Students)
				.HasForeignKey(s => s.group)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Group>()
				.HasOne(g => g.Direction)
				.WithMany(d => d.Groups)
				.HasForeignKey(g => g.direction)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Student>()
				.Property(s => s.group)
				.HasColumnName("group");
		}
	}
}