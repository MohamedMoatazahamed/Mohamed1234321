namespace WebApplication5.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public ICollection<task> Tasks { get; set; }
    }
}
