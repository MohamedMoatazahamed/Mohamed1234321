namespace FlightSystem.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public ICollection<Reservation> reservations { get; set; }
    }
}
