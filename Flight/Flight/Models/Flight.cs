namespace FlightSystem.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Airline { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime DateTime { get; set; }
        public int AvailableSeats { get; set; }
        public ICollection <Reservation> reservations { get; set; }
    } 
}
