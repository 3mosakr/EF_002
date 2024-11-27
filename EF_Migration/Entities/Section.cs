

namespace EF_Migration.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public string? SectionName { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public int? InstructorId { get; set; }
        public Instructor? Instructor { get; set; }

        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
        public ICollection<SectionSchedule> SectionSchedules = new List<SectionSchedule>();

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    }
}
