using System.ComponentModel.DataAnnotations.Schema;

namespace schoolsystem.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int classId { get; set; }
        [ForeignKey("classId")]
        public Class class1 {  get; set; }
        public int studentId { get; set; }
        [ForeignKey("studentId")]
        public Student student { get; set; }
        public int teatherID { get; set; }
        [ForeignKey("teatherID")]
        public Teacher Teacher{ get; set; }
        public DateTime Enroll {  get; set; }
  
    }
}
