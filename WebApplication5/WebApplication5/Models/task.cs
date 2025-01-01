using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
      
        public string Priority { get; set; }
        public DateTime Deadline { get; set; }
        public int projectID { get; set; }
        [ForeignKey("projectID")]
        public Project Project { get; set; }
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public TeamMember TeamMember { get; set; }
    }
}
