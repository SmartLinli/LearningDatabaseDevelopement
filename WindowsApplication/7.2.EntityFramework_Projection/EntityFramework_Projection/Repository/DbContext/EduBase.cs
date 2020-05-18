namespace EntityFramework_Projection
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	/// <summary>
	/// EduBase数据库上下文（SQL Server）；
	/// </summary>
	public partial class EduBase : DbContext
	{
		public EduBase()
			: base("EduBase")
		{
		}

		public virtual DbSet<Class> Class { get; set; }
		public virtual DbSet<Department> Department { get; set; }
		public virtual DbSet<Major> Major { get; set; }
		public virtual DbSet<Student> Student { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("dbo");
			modelBuilder.Entity<Department>().ToTable("tb_Department");
			modelBuilder.Entity<Major>().ToTable("tb_Major");
			modelBuilder.Entity<Class>().ToTable("tb_Class");
			modelBuilder.Entity<Student>().ToTable("tb_Student");

			modelBuilder.Entity<Class>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Class>()
				.HasMany(e => e.Student)
				.WithRequired(e => e.Class)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Department>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Department>()
				.HasMany(e => e.Major)
				.WithRequired(e => e.Department)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Major>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Major>()
				.HasMany(e => e.Class)
				.WithRequired(e => e.Major)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.No)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.PoliticalStatus)
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.Nationality)
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.Province)
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.City)
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.GraduateFrom)
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.IdentificationCard)
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.Phone)
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.Speciality)
				.IsUnicode(false);
		}
	}
}
