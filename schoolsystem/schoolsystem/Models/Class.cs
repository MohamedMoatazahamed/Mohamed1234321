namespace schoolsystem.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Schedule { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
