namespace EntityFramework_DbContext
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	/// <summary>
	/// EduBase数据库上下文（SQL Server）
	/// </summary>
	public abstract partial class EduBase : DbContext
	{
		public EduBase(string nameOrConnectionString)
			: base(nameOrConnectionString)
		{
		}

		public virtual DbSet<Class> Class { get; set; }
		public virtual DbSet<Student> Student { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Class>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Class>()
				.HasMany(e => e.tb_Student)
				.WithRequired(e => e.Class)
				.HasForeignKey(e => e.ClassNo)
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
