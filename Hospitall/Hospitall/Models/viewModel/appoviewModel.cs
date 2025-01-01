using System.ComponentModel.DataAnnotations.Schema;

namespace Hospitall.Models.viewModel
{
    public class appoviewModel
    {
        public int id { get; set; } 
        public DateTime Date { get; set; }
        public string notes { get; set; }
        public int PatId { get; set; }
        public int DoctId { get; set; }
        public ICollection<Doctor>? Doctors { get; set; }
        public ICollection<Patient>? patients { get; set; }



    }
}
