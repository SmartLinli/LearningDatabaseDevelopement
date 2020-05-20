namespace EntityFramework_Linq
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	/// <summary>
	/// EduBase数据库上下文（SQL Server）
	/// </summary>
	public partial class EduBaseSql : DbContext
	{
		public EduBaseSql()
			: base("name=EduBaseSql")
		{
		}

		public virtual DbSet<Course> Course { get; set; }
		public virtual DbSet<SelectedCourse> SelectedCourse { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Course>().ToTable("tb_Course");
			modelBuilder.Entity<SelectedCourse>().ToTable("tb_SelectedCourse");

			modelBuilder.Entity<Course>()
				.Property(e => e.No)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<Course>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Course>()
				.Property(e => e.Pinyin)
				.IsUnicode(false);

			modelBuilder.Entity<Course>()
				.Property(e => e.PreCourseNo)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<Course>()
				.Property(e => e.Credit)
				.HasPrecision(3, 1);

			modelBuilder.Entity<Course>()
				.Property(e => e.StudyType)
				.IsUnicode(false);

			modelBuilder.Entity<Course>()
				.Property(e => e.ExamType)
				.IsUnicode(false);

			modelBuilder.Entity<SelectedCourse>()
				.Property(e => e.StudentNo)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<SelectedCourse>()
				.Property(e => e.CourseNo)
				.IsFixedLength()
				.IsUnicode(false);
		}
	}
}
