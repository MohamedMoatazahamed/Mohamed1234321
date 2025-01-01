namespace Hospitall.Models
{
    public class Patient
    {
        public int PatId { get; set; }
        public string? PatName { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
     
    }
}
