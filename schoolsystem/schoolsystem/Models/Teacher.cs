namespace schoolsystem.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
