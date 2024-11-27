
using EF_Migration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Migration.Data.Config
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            // builder.Property(x => x.CourseName).HasMaxLength(255); // nvarchar(255)

            builder.Property(x => x.SectionName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            // Relationships
            // Required One to Many with Course [Dependent (Section) - Principal (Course)] [Cascade Delete]
            builder.HasOne(s => s.Course)
                .WithMany(c => c.Sections)
                .HasForeignKey(s => s.CourseId)
                .IsRequired();

            // Optional one-to-many with Instructor [Dependent (Section) - Principal (Course)] [Set null Delete]
            builder.HasOne(s => s.Instructor)
                .WithMany(i => i.Sections)
                .HasForeignKey(s => s.InstructorId)
                .IsRequired(false);

            // Many-to-many with named join table (SectionSchedule) with Schedule
            builder.HasMany(s => s.Schedules)
                .WithMany(s => s.Sections)
                .UsingEntity<SectionSchedule>();

            // Many-to-many with navigations to and from join entity (Enrollment) with Student
            builder.HasMany(s => s.Students)
                .WithMany(s => s.Sections)
                .UsingEntity<Enrollment>(
                    l => l.HasOne<Student>(s => s.Student).WithMany(e => e.Enrollments).HasForeignKey(e => e.StudentId),
                    r => r.HasOne<Section>(s => s.Section).WithMany(e => e.Enrollments).HasForeignKey(e => e.SectionId)
                );


            builder.ToTable("Sections");

            builder.HasData(LoadSections());
        }

        private static List<Section> LoadSections()
        {
            return new List<Section>
            {
                new Section { Id = 1, SectionName = "S_MA1", CourseId = 1, InstructorId = 1},
                new Section { Id = 2, SectionName = "S_MA2", CourseId = 1, InstructorId = 2},
                new Section { Id = 3, SectionName = "S_PH1", CourseId = 2, InstructorId = 1},
                new Section { Id = 4, SectionName = "S_PH2", CourseId = 2, InstructorId = 3},
                new Section { Id = 5, SectionName = "S_CH1", CourseId = 3, InstructorId =2},
                new Section { Id = 6, SectionName = "S_CH2", CourseId = 3, InstructorId = 3},
                new Section { Id = 7, SectionName = "S_BI1", CourseId = 4, InstructorId = 4},
                new Section { Id = 8, SectionName = "S_BI2", CourseId = 4, InstructorId = 5},
                new Section { Id = 9, SectionName = "S_CS1", CourseId = 5, InstructorId = 4},
                new Section { Id = 10, SectionName = "S_CS2", CourseId = 5, InstructorId = 5},
                new Section { Id = 11, SectionName = "S_CS3", CourseId = 5, InstructorId = 4}
            };
        }
    }
}
