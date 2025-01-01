using System.ComponentModel.DataAnnotations.Schema;

namespace schoolsystem.Models.viewmodel
{
    public class Enrollmentviewmodel
    {
        public int id;
        public int classId { get; set; }  
        public int studentId { get; set; }
        public int teatherID { get; set; }
        public DateTime Enroll { get; set; }

        public ICollection<Class> ClassList { get; set; }
        public ICollection<Student> StudentList { get; set; }
        public ICollection<Teacher> teacherList { get; set; }
    }
}
