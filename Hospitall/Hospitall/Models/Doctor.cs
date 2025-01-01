namespace Hospitall.Models
{
    public class Doctor
    {
        public int DocID {  get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

    }
}
