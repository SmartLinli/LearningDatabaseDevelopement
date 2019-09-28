namespace Record_Control_Orm
{
	using SmartLinli.DatabaseDevelopement;
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class EduBaseSql : SqlContext
	{
		public EduBaseSql()
			: base()
		{
		}

		public virtual DbSet<Class> Class { get; set; }
		public virtual DbSet<Student> Student { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Class>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Class>()
				.HasMany(e => e.Student)
				.WithRequired(e => e.Class)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.No)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.Speciality)
				.IsUnicode(false);
		}
	}
}
