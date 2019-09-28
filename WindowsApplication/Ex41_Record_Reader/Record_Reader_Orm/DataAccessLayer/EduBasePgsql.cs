namespace Record_Reader_Orm
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using SmartLinli.DatabaseDevelopement;

	public partial class EduBasePgsql : PgsqlContext
	{
		public EduBasePgsql()
			: base()
		{
		}

		public virtual DbSet<Student> Student { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Student>()
				.Property(e => e.No)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.Gender)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.Class)
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.Speciality)
				.IsUnicode(false);
		}
	}
}
