using Microsoft.AspNetCore.Identity;

namespace Task_Management.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Double PhoneNumber { get; set; }
        public ICollection<Task1> Tasks { get; set; }    
    }
}
