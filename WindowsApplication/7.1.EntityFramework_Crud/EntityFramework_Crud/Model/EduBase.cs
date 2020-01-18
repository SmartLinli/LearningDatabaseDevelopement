namespace EntityFramework_Crud
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class EduBase : DbContext
	{
		public EduBase()
			: base("name=EduBase")
		{
		}

		public virtual DbSet<Class> Class { get; set; }
		public virtual DbSet<Course> Course { get; set; }
		public virtual DbSet<Department> Department { get; set; }
		public virtual DbSet<Major> Major { get; set; }
		public virtual DbSet<Student> Student { get; set; }
		public virtual DbSet<StudentScore> StudentScore { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Class>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Class>()
				.HasMany(e => e.Student)
				.WithRequired(e => e.Class)
				.WillCascadeOnDelete(false);

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
				.Property(e => e.StudyTypeNo)
				.IsUnicode(false);

			modelBuilder.Entity<Course>()
				.Property(e => e.ExamTypeNo)
				.IsUnicode(false);

			modelBuilder.Entity<Course>()
				.HasMany(e => e.StudentScore)
				.WithRequired(e => e.Course)
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

			modelBuilder.Entity<StudentScore>()
				.Property(e => e.StudentNo)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<StudentScore>()
				.Property(e => e.CourseNo)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<StudentScore>()
				.Property(e => e.BasicScore)
				.HasPrecision(4, 1);

			modelBuilder.Entity<StudentScore>()
				.Property(e => e.FinalScore)
				.HasPrecision(4, 1);

			modelBuilder.Entity<StudentScore>()
				.Property(e => e.TotalScore)
				.HasPrecision(4, 1);

			modelBuilder.Entity<StudentScore>()
				.Property(e => e.FacultyRate)
				.HasPrecision(4, 1);
		}
	}
}
