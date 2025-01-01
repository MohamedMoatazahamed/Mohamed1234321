using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models.viewmodel
{
    public class taskviewmodel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public string Priority { get; set; }
        public DateTime Deadline { get; set; }
        public int projectID { get; set; }


        public int TeamId { get; set; }
        public ICollection<TeamMember> teamMembers { get; set; }
        public ICollection<Project> projects { get; set; }
    
    }
}
