using System.ComponentModel.DataAnnotations.Schema;

namespace Hospitall.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string notes { get; set; }
        public int PatId { get; set; }
        [ForeignKey ("PatId")]
       public Patient Patient   { get; set; }
        public int DoctId { get; set; }
        [ForeignKey("DoctId")]
        public Doctor Doctor { get; set; }

    }
}
