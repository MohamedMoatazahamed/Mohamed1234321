using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        [ForeignKey("PassengerId")]
        public Passenger Passenger { get; set; }
        public int FlightId { get; set; }
        [ForeignKey("FlightId")]
        public Flight Flight{ get; set; }
        public DateTime ReservationDate { get; set; }
           public string Status { get; set; }
    }
}
