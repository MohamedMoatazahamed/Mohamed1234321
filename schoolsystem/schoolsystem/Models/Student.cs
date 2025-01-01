namespace schoolsystem.Models
{
    public class Student
    {
        public int id { get; set; }
        public string StuName {get; set;}
        public int Age { get; set; }
        public string Gendr { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}