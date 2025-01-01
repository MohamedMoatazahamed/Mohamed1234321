using FlightSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSystem.Models.viewmodel
{
    public class Reservationviewmodel
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }


        public int FlightId { get; set; }


        public DateTime ReservationDate { get; set; }
        public string Status { get; set; }
        public ICollection<Flight> flights { get; set; }
        public ICollection<Passenger> passengers { get; set; }

    }
}
