using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Management.Models
{
    public class Task1
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public int AssignedUserId { get; set; }
        [ForeignKey("AssignedUserId")]
        public User User    { get; set; }
        public string Status {  get; set; }
        public DateTime DueDate { get; set; }


    }
}
