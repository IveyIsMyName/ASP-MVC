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

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=AcademyDB;Trusted_Connection=true;TrustServerCertificate=true");
			}

			// Отключаем проверки миграций
			optionsBuilder.EnableServiceProviderCaching(false);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Student>().ToTable("Students");
			//modelBuilder.Entity<Teacher>().ToTable("Teachers");
			//modelBuilder.Entity<Group>().ToTable("Groups");
			//modelBuilder.Entity<Direction>().ToTable("Directions");

			modelBuilder.Entity<Student>(entity =>
			{
				entity.ToTable("Students");
				entity.HasKey(e => e.stud_id);
			});
			modelBuilder.Entity<Teacher>(entity =>
			{
				entity.ToTable("Teachers");
				entity.HasKey(e => e.teacher_id);
			});
			modelBuilder.Entity<Group>(entity =>
			{
				entity.ToTable("Groups");
				entity.HasKey(e => e.group_id);
			});
			modelBuilder.Entity<Direction>(entity =>
			{
				entity.ToTable("Directions");
				entity.HasKey(e => e.direction_id);
			});

			//modelBuilder.Entity<Student>().HasKey(s => s.stud_id);
			//modelBuilder.Entity<Teacher>().HasKey(t => t.teacher_id);
			//modelBuilder.Entity<Group>().HasKey(g => g.group_id);
			//modelBuilder.Entity<Direction>().HasKey(d => d.direction_id);

			// Настройка связей
			modelBuilder.Entity<Student>()
				.HasOne(s => s.Groups)
				.WithMany(g => g.Students)
				.HasForeignKey(s => s.group_id)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Group>()
				.HasOne(g => g.Direction)
				.WithMany(d => d.Groups)
				.HasForeignKey(g => g.direction)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Student>()
				.Property(s => s.group_id)
				.HasColumnName("group");
		}
	}
}
