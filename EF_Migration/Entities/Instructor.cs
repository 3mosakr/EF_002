

namespace EF_Migration.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }

        public int? OfficeId { get; set; } // Required foreign key property
        public Office? Office { get; set; } // Required reference navigation to principal (Office)

        public ICollection<Section> Sections { get; set; } = new List<Section>();

    }
}
